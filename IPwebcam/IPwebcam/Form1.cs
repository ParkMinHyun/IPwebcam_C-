using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MjpegProcessor;
namespace IPwebcam
{
    public partial class Form1 : Form
    {
        MjpegDecoder mjp;
        private bool flag = false;
        public Form1()
        {
            InitializeComponent();
            
            mjp = new MjpegDecoder();
            mjp.FrameReady += mjp_frameReady;
            mjp.ParseStream(new Uri("http://172.30.1.49:8080/videofeed"));
        }


        void mjp_frameReady(object sender, FrameReadyEventArgs e)
        {
            pictureBox1.Image = e.Bitmap;

            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag.Equals(false))
            {
                mjp.StopStream();
                flag = true;
            }

            else
            {
                mjp.ParseStream(new Uri("http://172.30.1.49:8080/videofeed"));
                flag = false;
            }
        }
    }
}