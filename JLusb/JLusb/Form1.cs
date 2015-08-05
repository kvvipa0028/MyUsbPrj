using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using WMPLib;

namespace JLusb
{
    public partial class Form1 : Form
    {
        private JLusb jlusb = null;
        //private WindowsMediaPlayer mWinMediaPlayer;
        public Form1()
        {
            InitializeComponent();
            // initilize JLusb 
            jlusb = new JLusb();
            // initilize WindowsMediaPlayer
            //mWinMediaPlayer = new WindowsMediaPlayer();
            //mWinMediaPlayer.openPlayer("E:\\迅雷下载\\J点_bd.mp4");
            PicBox.Load("http://images.china.cn/attachement/jpg/site1000/20150803/c03fd556687217294d854a.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jlusb.get_video();
            Bitmap mp = new Bitmap(PicBox.Image);
            //mp.PixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            Bitmap img = mp.Clone(new Rectangle(0, 0, mp.Width, mp.Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            PicBox.Image = ToGray(mp);
            //pictureBox1.Image = ToGray(mp);
        }
        /// <summary>
        /// 图像灰度化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        private Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = bmp.GetPixel(i, j);
                    //利用公式计算灰度值
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
    }
}
