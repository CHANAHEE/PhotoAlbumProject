namespace SharedPhotoAlbum
{
    partial class ImageControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox_Image = new PictureBox();
            panel_Image = new Panel();
            panel1 = new Panel();
            label_Name = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).BeginInit();
            panel_Image.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_Image
            // 
            pictureBox_Image.BackColor = Color.Transparent;
            pictureBox_Image.Dock = DockStyle.Fill;
            pictureBox_Image.Image = Properties.Resources.Folder;
            pictureBox_Image.Location = new Point(50, 50);
            pictureBox_Image.Name = "pictureBox_Image";
            pictureBox_Image.Size = new Size(155, 116);
            pictureBox_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Image.TabIndex = 0;
            pictureBox_Image.TabStop = false;
            pictureBox_Image.MouseEnter += pictureBox_Image_MouseEnter;
            pictureBox_Image.MouseLeave += pictureBox_Image_MouseLeave;
            // 
            // panel_Image
            // 
            panel_Image.BackColor = Color.Transparent;
            panel_Image.Controls.Add(pictureBox_Image);
            panel_Image.Controls.Add(panel1);
            panel_Image.Dock = DockStyle.Fill;
            panel_Image.Location = new Point(0, 0);
            panel_Image.Name = "panel_Image";
            panel_Image.Padding = new Padding(50);
            panel_Image.Size = new Size(255, 249);
            panel_Image.TabIndex = 1;
            panel_Image.MouseEnter += panel_Image_MouseEnter;
            panel_Image.MouseLeave += panel_Image_MouseLeave;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_Name);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(50, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(155, 33);
            panel1.TabIndex = 2;
            // 
            // label_Name
            // 
            label_Name.Dock = DockStyle.Fill;
            label_Name.Location = new Point(0, 0);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(155, 33);
            label_Name.TabIndex = 1;
            label_Name.Text = "label1";
            label_Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_Image);
            Name = "ImageControl";
            Size = new Size(255, 249);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).EndInit();
            panel_Image.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_Image;
        private Panel panel_Image;
        private Panel panel1;
        private Label label_Name;
    }
}
