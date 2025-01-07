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
            this.BeginInvoke(new Action(() => AfterEdit(e.Node)));
        }

        private void AfterEdit(TreeNode Node)
        {
            bool IsDuplicated = DuplicateFolderCheck(Node.Text, this.treeView_Folder.Nodes, Node.Level, 0);

            if (IsDuplicated == true)
            {
                MessageBox.Show("같은 이름의 폴더가 이미 존재합니다.", "중복 폴더 제한", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Node.Remove();

                return;
            }

            // 실제 경로에 추가
            string FolderPath = Path.Combine(rootPath, Node.Text);

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        private bool DuplicateFolderCheck(string CurrentFolderName, TreeNodeCollection Nodes, int TargetLevel, int CurrentLevel)
        {
            foreach (TreeNode Node in Nodes)
            {
                if (CurrentLevel == TargetLevel)
                {
                    if(Node.Text == CurrentFolderName)
                    {
                        return true;
                    }
                }

                if (Node.Nodes.Count > 0)
                {
                    DuplicateFolderCheck(CurrentFolderName, Node.Nodes, TargetLevel, CurrentLevel + 1);
                }
            }

            return false;
        }

        private void toolStripMenuItem_DeleteFolder_Click(object sender, EventArgs e)
        {

        }


    }
}
