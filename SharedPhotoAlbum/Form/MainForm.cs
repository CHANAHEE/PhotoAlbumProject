using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SharedPhotoAlbum
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            string RootPath = "C:\\PhotoAlbum";

            TreeNode RootNode = new TreeNode(RootPath);
            this.treeView_Folder.Nodes.Add(RootNode);
            AddDirectoriesToTree(RootNode, RootPath);

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

        }

        private void toolStripMenuItem_DeleteFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
