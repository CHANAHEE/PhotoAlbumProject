using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
