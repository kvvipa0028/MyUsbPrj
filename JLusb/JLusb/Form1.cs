using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JLmatlabNative;
//using WMPLib;

namespace JLusb
{
    public partial class Form1 : Form
    {
        private JLusb jlusb = null;
        //private WindowsMediaPlayer mWinMediaPlayer;

        private JLvideo jlvideo = null;
        public Form1()
        {
            InitializeComponent();
            // initilize JLusb 
            jlusb = new JLusb();
            // initilize JLvideo
            jlvideo = new JLvideo();
            // initilize WindowsMediaPlayer
            //mWinMediaPlayer = new WindowsMediaPlayer();
            //mWinMediaPlayer.openPlayer("E:\\迅雷下载\\J点_bd.mp4");
            //PicBox.Load("http://images.china.cn/attachement/jpg/site1000/20150803/c03fd556687217294d854a.jpg");
            PicBox.Load("o.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jlusb.get_video();
            Bitmap mp = new Bitmap(PicBox.Image);
            pictureBox1.Image = mp;
            //mp.PixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            Bitmap img = mp.Clone(new Rectangle(0, 0, mp.Width, mp.Height), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            //Bitmap mmp = ToGray(mp);
            Bitmap mmp = mp;
            PicBox.Image = mmp;
            jlvideo.set_Image(mmp);
            //jlvideo.Start();
            //jlvideo.test();
            //pictureBox1.Image = ToGray(mp);
            //(mmp);
            //hist(mmp);
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

        private void button2_Click(object sender, EventArgs e)
        {
            //jlvideo.Stop();
            jlvideo.test_read();
        }
        
        private void chart_Histgram(Object sender, PaintEventArgs e)
        {
            int[] xlabel = new int[256];
            Bitmap mp = jlvideo.get_Image();
            for (int i = 0; i < mp.Width; i++)
            {
                for (int j = 0; j < mp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = mp.GetPixel(i, j);
                    //利用公式计算灰度值
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    xlabel[gray] = xlabel[gray] + 1;
                    //xlabel[mp.GetPixel(i,j)] = xlabel
                }
            }

            // drawing a histgram
            Pen mpen = new Pen(Brushes.Black,2);
            //Graphics mg = e.Graphics;
            //mg.DrawLine(mpen, 300, 240, 50, 320);

        }
        private void hist(Bitmap mp)
        {
            int[] xlabel = new int[256];
            for (int i = 0; i < mp.Width; i++)
            {
                for (int j = 0; j < mp.Height; j++)
                {
                    //获取该点的像素的RGB的颜色
                    Color color = mp.GetPixel(i, j);
                    //利用公式计算灰度值
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    xlabel[gray] = xlabel[gray] + 1;
                    //xlabel[mp.GetPixel(i,j)] = xlabel
                }
            }
            //Graphics mgra = pictureBox1.CreateGraphics();
            Graphics mgra = Graphics.FromImage(mp);
            Pen mpen = new Pen(Brushes.Black, 2);
            //mgra.DrawLine(mpen, new Point(256,0), new Point(0,mp.Height * mp.Width));
            mgra.DrawLine(mpen, 50, 50, 300, 250);
            pictureBox1.Image = mp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JLmatlab histt = new JLmatlab();
            Bitmap ae = (Bitmap)histt.histgram(jlvideo.get_Image());
            pictureBox2.Image = ae;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JLhistgram jlhist = new JLhistgram();
            jlhist.HistgramCompute(jlvideo.get_Image());
            pictureBox2.Image = jlhist.HistgramShow();

        }
    }
}
