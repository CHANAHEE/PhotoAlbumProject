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
            splitContainer1 = new SplitContainer();
            treeView_Folder = new TreeView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            // 
            // MainForm
            // 
            ClientSize = new Size(1106, 665);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView_Folder;
    }
}