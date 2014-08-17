using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttons
{
    public partial class ImageForm : Form
    {
        public ImageForm(String image)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Width = pictureBox1.Image.Width;
            Height = pictureBox1.Image.Height;
            Point old = Location;
            old.X = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
            old.Y = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            Location = old;
        }
    }
}
