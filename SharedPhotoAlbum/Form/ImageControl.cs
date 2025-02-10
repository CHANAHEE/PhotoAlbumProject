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
    public partial class ImageControl : UserControl
    {
        private bool isMouseInside = false;

        public ImageControl()
        {
            InitializeComponent();
        }

        public void SetImage(Image Image)
        {
            this.pictureBox_Image.Image = Image;
        }

        public void SetSizeMode(PictureBoxSizeMode SizeMode)
        {
            this.pictureBox_Image.SizeMode = SizeMode;
        }

        public void SetItemName(string Name)
        {
            this.label_Name.Text = Name;
        }

        private void pictureBox_Image_MouseEnter(object sender, EventArgs e)
        {
            //if (isMouseInside == false)
            //{
            //    isMouseInside = true;
            //    this.BackColor = Color.FromArgb(209, 219, 231);
            //}
        }

        private void pictureBox_Image_MouseLeave(object sender, EventArgs e)
        {
            //if (isMouseInside)
            //{
            //    if (sender is PictureBox ImgBox && !ImgBox.ClientRectangle.Contains(ImgBox.PointToClient(Cursor.Position)))
            //    {
            //        isMouseInside = false;
            //        this.BackColor = SystemColors.Control;
            //    }
            //}
        }

        private void panel_Image_MouseLeave(object sender, EventArgs e)
        {
            if (isMouseInside)
            {
                if (sender is Panel panel && !panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                {
                    isMouseInside = false;
                    this.BackColor = SystemColors.Control;
                }
            }
        }

        private void panel_Image_MouseEnter(object sender, EventArgs e)
        {
            if (isMouseInside == false)
            {
                isMouseInside = true;
                this.BackColor = Color.FromArgb(209, 219, 231);
            }
        }
    }
}
