﻿namespace SharedPhotoAlbum
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
            contextMenuStrip_FolderManaging = new ContextMenuStrip(components);
            toolStripMenuItem_AddFolder = new ToolStripMenuItem();
            toolStripMenuItem_DeleteFolder = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
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
            splitContainer1.Size = new Size(1106, 665);
            splitContainer1.SplitterDistance = 228;
            splitContainer1.TabIndex = 0;
            // 
            // treeView_Folder
            // 
            treeView_Folder.Dock = DockStyle.Fill;
            treeView_Folder.Location = new Point(0, 0);
            treeView_Folder.Name = "treeView_Folder";
            treeView_Folder.Size = new Size(228, 665);
            treeView_Folder.TabIndex = 0;
            treeView_Folder.MouseUp += treeView_Folder_MouseUp;
            // 
            // contextMenuStrip_FolderManaging
            // 
            contextMenuStrip_FolderManaging.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_AddFolder, toolStripMenuItem_DeleteFolder });
            contextMenuStrip_FolderManaging.Name = "contextMenuStrip1";
            contextMenuStrip_FolderManaging.Size = new Size(127, 48);
            // 
            // toolStripMenuItem_AddFolder
            // 
            toolStripMenuItem_AddFolder.Name = "toolStripMenuItem_AddFolder";
            toolStripMenuItem_AddFolder.Size = new Size(126, 22);
            toolStripMenuItem_AddFolder.Text = "폴더 추가";
            toolStripMenuItem_AddFolder.Click += toolStripMenuItem_AddFolder_Click;
            // 
            // toolStripMenuItem_DeleteFolder
            // 
            toolStripMenuItem_DeleteFolder.Name = "toolStripMenuItem_DeleteFolder";
            toolStripMenuItem_DeleteFolder.Size = new Size(126, 22);
            toolStripMenuItem_DeleteFolder.Text = "폴더 삭제";
            toolStripMenuItem_DeleteFolder.Click += toolStripMenuItem_DeleteFolder_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1106, 665);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
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
    }
}