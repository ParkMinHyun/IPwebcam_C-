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
        public Form1()
        {
            InitializeComponent();
            mjp = new MjpegDecoder();
            mjp.FrameReady += mjp_frameReady;
            mjp.ParseStream(new Uri("http://192.168.0.23:8080/videofeed"));
        }


        void mjp_frameReady(object sender, FrameReadyEventArgs e)
        {
            pictureBox1.Image = e.Bitmap;

            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Image = img;
        }
    }
}