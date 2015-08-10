using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace JLusb
{
    public class JLhistgram
    {
        private Bitmap mHist;
        private int[] xlabel = new int[256];
        Array mImage;

        public JLhistgram()
        {
            mHist = new Bitmap(320, 420);
        }
        public JLhistgram(Bitmap bm)
        {
            mHist = bm;
        }

        public void HistgramCompute(Bitmap bm)
        {
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Color mcolor = bm.GetPixel(i, j);
                    //利用公式计算灰度值
                    int gray = (int)(mcolor.R * 0.3 + mcolor.G * 0.59 + mcolor.B * 0.11);
                    //int gray = mcolor.R;
                    xlabel[gray] = xlabel[gray] + 1;
                }
            }
        }
        public Bitmap HistgramShow()
        {
            Graphics mgra = Graphics.FromImage(mHist);
            Pen mpen = new Pen(Brushes.Black, 2);
            Pen mpen2 = new Pen(Brushes.Red, 6);

            int [] tlabel = new int [256];
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum = sum + xlabel[i];
            }

            mgra.DrawLine(mpen, 10, 310, 410, 310); // x line
            for (int i = 0; i < 256; i++)
            {
                //mgra.DrawString(i.ToString(),new Font("宋体", 9, FontStyle.Bold),mbru,10+i*1.5,310);
                mgra.DrawLine(mpen, 10+i*2, 312, 10+i*2+1, 312); // x line
                mgra.DrawLine(mpen, 10 + i * 2, (int)(312-xlabel[i]*450/sum), 10 + i * 2 + 1, 312); // x line
            }
            mgra.DrawLine(mpen, 10, 10, 10, 310);   // y line

            return mHist;
        }
        
    }
}