namespace SharedPhotoAlbum
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            treeView_Folder = new TreeView();
            flowLayoutPanel_Image = new FlowLayoutPanel();
            contextMenuStrip_FolderManaging = new ContextMenuStrip(components);
            toolStripMenuItem_AddFolder = new ToolStripMenuItem();
            toolStripMenuItem_DeleteFolder = new ToolStripMenuItem();
            toolStripMenuItem_Rename = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip_FolderManaging.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView_Folder);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel_Image);
            splitContainer1.Size = new Size(1106, 665);
            splitContainer1.SplitterDistance = 228;
            splitContainer1.TabIndex = 0;
            // 
            // treeView_Folder
            // 
            treeView_Folder.Dock = DockStyle.Fill;
            treeView_Folder.Font = new Font("맑은 고딕", 11F);
            treeView_Folder.Indent = 14;
            treeView_Folder.ItemHeight = 25;
            treeView_Folder.Location = new Point(0, 0);
            treeView_Folder.Name = "treeView_Folder";
            treeView_Folder.Size = new Size(228, 665);
            treeView_Folder.TabIndex = 0;
            treeView_Folder.AfterLabelEdit += treeView_Folder_AfterLabelEdit;
            treeView_Folder.AfterSelect += treeView_Folder_AfterSelect;
            treeView_Folder.MouseUp += treeView_Folder_MouseUp;
            // 
            // flowLayoutPanel_Image
            // 
            flowLayoutPanel_Image.Dock = DockStyle.Fill;
            flowLayoutPanel_Image.Location = new Point(0, 0);
            flowLayoutPanel_Image.Name = "flowLayoutPanel_Image";
            flowLayoutPanel_Image.Size = new Size(874, 665);
            flowLayoutPanel_Image.TabIndex = 0;
            // 
            // contextMenuStrip_FolderManaging
            // 
            contextMenuStrip_FolderManaging.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_AddFolder, toolStripMenuItem_DeleteFolder, toolStripMenuItem_Rename });
            contextMenuStrip_FolderManaging.Name = "contextMenuStrip1";
            contextMenuStrip_FolderManaging.Size = new Size(139, 70);
            // 
            // toolStripMenuItem_AddFolder
            // 
            toolStripMenuItem_AddFolder.Name = "toolStripMenuItem_AddFolder";
            toolStripMenuItem_AddFolder.Size = new Size(138, 22);
            toolStripMenuItem_AddFolder.Text = "폴더 추가";
            toolStripMenuItem_AddFolder.Click += toolStripMenuItem_AddFolder_Click;
            // 
            // toolStripMenuItem_DeleteFolder
            // 
            toolStripMenuItem_DeleteFolder.Name = "toolStripMenuItem_DeleteFolder";
            toolStripMenuItem_DeleteFolder.Size = new Size(138, 22);
            toolStripMenuItem_DeleteFolder.Text = "폴더 삭제";
            toolStripMenuItem_DeleteFolder.Click += toolStripMenuItem_DeleteFolder_Click;
            // 
            // toolStripMenuItem_Rename
            // 
            toolStripMenuItem_Rename.Name = "toolStripMenuItem_Rename";
            toolStripMenuItem_Rename.Size = new Size(138, 22);
            toolStripMenuItem_Rename.Text = "이름 바꾸기";
            toolStripMenuItem_Rename.Click += toolStripMenuItem_Rename_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1106, 665);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip_FolderManaging.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView_Folder;
        private ContextMenuStrip contextMenuStrip_FolderManaging;
        private ToolStripMenuItem toolStripMenuItem_AddFolder;
        private ToolStripMenuItem toolStripMenuItem_DeleteFolder;
        private ToolStripMenuItem toolStripMenuItem_Rename;
        private FlowLayoutPanel flowLayoutPanel_Image;
    }
}