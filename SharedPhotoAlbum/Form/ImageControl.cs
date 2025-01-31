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
        public ImageControl()
        {
            InitializeComponent();
        }

        public void SetImage(Image Image)
        {
            this.pictureBox1.Image = Image;
        }

        public void SetSizeMode(PictureBoxSizeMode SizeMode)
        {
            this.pictureBox1.SizeMode = SizeMode;
        }

        public void SetItemName(string Name)
        {
            this.label_Name.Text = Name;
        }
    }
}
