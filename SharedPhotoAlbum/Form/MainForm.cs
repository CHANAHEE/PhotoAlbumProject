using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SharedPhotoAlbum
{
    public partial class MainForm : Form
    {
        private string drivePath = "C:";
        private string rootPath = "C:\\PhotoAlbum";
        private string syncPath = "C:\\PhotoAlbum\\Sync";
        private bool isRename = false;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            //폴더 생성 및 트리뷰 초기화
            DirectoryInfo RootDirecInfo = new DirectoryInfo(rootPath);
            if (RootDirecInfo.Exists == false)
            {
                Directory.CreateDirectory(rootPath);
                RootDirecInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            DirectoryInfo SyncDirecInfo = new DirectoryInfo(syncPath);
            if (SyncDirecInfo.Exists == false)
            {
                Directory.CreateDirectory(syncPath);
                SyncDirecInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            TreeNode RootNode = new TreeNode(RootDirecInfo.Name);
            this.treeView_Folder.Nodes.Add(RootNode);
            AddDirectoriesToTree(RootNode, rootPath);

            this.treeView_Folder.LabelEdit = true;

            //폼 이름 변경
            this.Text = "";
        }

        private void AddDirectoriesToTree(TreeNode ParentNode, string RootPath)
        {
            try
            {
                string[] Directories = Directory.GetDirectories(RootPath);

                foreach (string Directory in Directories)
                {
                    TreeNode DirectoryNode = new TreeNode(Path.GetFileName(Directory));
                    if(DirectoryNode.Text == syncPath.Split('\\').Last())
                    {
                        ParentNode.Nodes.Insert(0, DirectoryNode);
                    }
                    else
                    {
                        ParentNode.Nodes.Add(DirectoryNode);
                    }                    

                    AddDirectoriesToTree(DirectoryNode, Directory);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void treeView_Folder_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode ClickedNode = this.treeView_Folder.GetNodeAt(e.X, e.Y);

                if (ClickedNode == null)
                {
                    this.toolStripMenuItem_DeleteFolder.Enabled = false;
                    this.toolStripMenuItem_AddFolder.Enabled = false;
                    this.toolStripMenuItem_Rename.Enabled = false;

                    this.treeView_Folder.SelectedNode = ClickedNode;
                    this.contextMenuStrip_FolderManaging.Show(this.treeView_Folder, e.Location);
                }
                else
                {
                    this.toolStripMenuItem_DeleteFolder.Enabled = true;
                    this.toolStripMenuItem_AddFolder.Enabled = true;
                    this.toolStripMenuItem_Rename.Enabled = true;

                    this.treeView_Folder.SelectedNode = ClickedNode;
                    this.contextMenuStrip_FolderManaging.Show(this.treeView_Folder, e.Location);
                }
            }
        }

        private void toolStripMenuItem_AddFolder_Click(object sender, EventArgs e)
        {
            isRename = false;

            TreeNode SelectedNode = this.treeView_Folder.SelectedNode;

            if (SelectedNode.Level == 2)
            {
                MessageBox.Show("폴더를 생성할 수 없습니다!", "폴더 깊이 제한", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedNode != null)
            {
                TreeNode NewFolderNode = new TreeNode("새 폴더");
                SelectedNode.Nodes.Add(NewFolderNode);

                this.treeView_Folder.SelectedNode = NewFolderNode;
                this.treeView_Folder.SelectedNode.BeginEdit();
            }
        }

        private void treeView_Folder_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.Tag = e.Node.Text;
            string OldPath = Path.Combine(drivePath, e.Node.FullPath);
            this.BeginInvoke(new Action(() => AfterEdit(e.Node, OldPath)));
        }

        private void AfterEdit(TreeNode Node, string OldPath)
        {
            bool IsDuplicated = Directory.Exists(Path.Combine(drivePath, Node.FullPath));

            if (isRename == false)
            {
                if (IsDuplicated == true)
                {
                    MessageBox.Show("같은 이름의 폴더가 이미 존재합니다.", "중복 폴더 제한", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Node.Remove();

                    return;
                }

                // 실제 경로에 추가
                string FolderPath = Path.Combine(drivePath, Node.FullPath);

                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
            }
            else
            {
                if (IsDuplicated == true)
                {
                    MessageBox.Show("같은 이름의 폴더가 이미 존재합니다.", "중복 폴더 제한", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Node.Text = (string)Node.Tag;
                    return;
                }

                // 실제 경로에 이름 변경
                string OldFolderPath = OldPath;
                string NewFolderPath = Path.Combine(drivePath, Node.FullPath);

                if (Directory.Exists(OldFolderPath))
                {
                    Directory.Move(OldFolderPath, NewFolderPath);
                }
            }
        }

        private void toolStripMenuItem_DeleteFolder_Click(object sender, EventArgs e)
        {
            TreeNode SelectedNode = this.treeView_Folder.SelectedNode;

            // 실제 경로에서 삭제
            string FolderPath = Path.Combine(drivePath, SelectedNode.FullPath);

            if (FolderPath == rootPath)
            {
                MessageBox.Show("최상위 폴더는 삭제할 수 없습니다", "권한 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult Result = MessageBox.Show("폴더를 삭제하시겠습니까?", "폴더 삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Result == DialogResult.OK)
            {
                if (Directory.Exists(FolderPath))
                {
                    Directory.Delete(FolderPath, true);
                }

                if (SelectedNode != null)
                {
                    SelectedNode.Remove();
                }
            }
            else
            {
                return;
            }
        }

        private void toolStripMenuItem_Rename_Click(object sender, EventArgs e)
        {
            isRename = true;

            TreeNode SelectedNode = this.treeView_Folder.SelectedNode;

            if (Path.Combine(drivePath, SelectedNode.FullPath) == rootPath)
            {
                MessageBox.Show("최상위 폴더의 이름은 변경할 수 없습니다", "권한 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SelectedNode != null)
            {
                SelectedNode.BeginEdit();
            }
        }

        private void treeView_Folder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string SelectedPath = Path.Combine(drivePath, e.Node.FullPath); // 선택한 노드의 경로
            ShowFiles(SelectedPath);
        }

        private void ShowFiles(string Path)
        {
            this.flowLayoutPanel_Image.Controls.Clear();

            if (Directory.Exists(Path) == false)
            {
                Console.WriteLine($"{Path} 에 폴더가 존재하지 않습니다.");
                return;
            }

            string[] Directories = Directory.GetDirectories(Path);
            string[] Images = Directory.GetFiles(Path);

            foreach (var Directory in Directories)
            {
                if(Directory == syncPath)
                {
                    continue;
                }

                ImageControl FolderIcon = new ImageControl();
                FolderIcon.SetImage(Properties.Resources.Folder);
                FolderIcon.SetSizeMode(PictureBoxSizeMode.StretchImage);
                FolderIcon.Size = new Size(200, 200);
                FolderIcon.Tag = Directory;
                FolderIcon.SetItemName(Directory.Split("\\").Last());

                this.flowLayoutPanel_Image.Controls.Add(FolderIcon);
            }

            foreach (var Image in Images)
            {
                if (IsImageFile(Image))  
                {
                    ImageControl ImageIcon = new ImageControl();                    
                    ImageIcon.SetImage(System.Drawing.Image.FromFile(Image));
                    ImageIcon.SetSizeMode(PictureBoxSizeMode.Zoom);
                    ImageIcon.Size = new Size(200, 200);
                    ImageIcon.Tag = Image;
                    ImageIcon.SetItemName(Image.Split("\\").Last());

                    this.flowLayoutPanel_Image.Controls.Add(ImageIcon);
                }
            }
        }

        private bool IsImageFile(string FilePath)
        {
            string[] ImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return ImageExtensions.Contains(Path.GetExtension(FilePath).ToLower());
        }
    }
}
