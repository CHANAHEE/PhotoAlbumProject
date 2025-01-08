using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SharedPhotoAlbum
{
    public partial class MainForm : Form
    {
        private string rootPath = "C:\\PhotoAlbum";
        private bool isRename = false;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            TreeNode RootNode = new TreeNode(rootPath);
            this.treeView_Folder.Nodes.Add(RootNode);
            AddDirectoriesToTree(RootNode, rootPath);

            this.treeView_Folder.LabelEdit = true;
        }

        private void AddDirectoriesToTree(TreeNode ParentNode, string RootPath)
        {
            try
            {
                string[] Directories = Directory.GetDirectories(RootPath);

                foreach (string Directory in Directories)
                {
                    TreeNode DirectoryNode = new TreeNode(Path.GetFileName(Directory));
                    ParentNode.Nodes.Add(DirectoryNode);

                    AddDirectoriesToTree(DirectoryNode, Directory);
                }

                string[] Files = Directory.GetFiles(RootPath);

                foreach (string File in Files)
                {
                    TreeNode FileNode = new TreeNode(Path.GetFileName(File));
                    ParentNode.Nodes.Add(FileNode);
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
                    this.toolStripMenuItem_AddFolder.Enabled = true;

                    this.treeView_Folder.SelectedNode = ClickedNode;
                    this.contextMenuStrip_FolderManaging.Show(this.treeView_Folder, e.Location);
                }
                else
                {
                    this.toolStripMenuItem_DeleteFolder.Enabled = true;
                    this.toolStripMenuItem_AddFolder.Enabled = true;

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
            string OldPath = e.Node.FullPath;
            this.BeginInvoke(new Action(() => AfterEdit(e.Node, OldPath)));
        }

        private void AfterEdit(TreeNode Node, string OldPath)
        {
            bool IsDuplicated = Directory.Exists(Node.FullPath);

            if (IsDuplicated == true)
            {
                MessageBox.Show("같은 이름의 폴더가 이미 존재합니다.", "중복 폴더 제한", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Node.Remove();

                return;
            }

            if(isRename == false) 
            {
                // 실제 경로에 추가
                string FolderPath = Node.FullPath;

                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
            }
            else
            {
                // 실제 경로에 이름 변경                
                string OldFolderPath = OldPath;
                string NewFolderPath = Node.FullPath;

                if (Directory.Exists(OldFolderPath))
                {
                    Directory.Move(OldFolderPath, NewFolderPath);
                }
            }
        }

        private void toolStripMenuItem_DeleteFolder_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("폴더를 삭제하시겠습니까?", "폴더 삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Result == DialogResult.OK)
            {
                TreeNode SelectedNode = this.treeView_Folder.SelectedNode;

                // 실제 경로에서 삭제
                string FolderPath = SelectedNode.FullPath;

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

            if (SelectedNode != null)
            {
                SelectedNode.BeginEdit();
            }
        }
    }
}
