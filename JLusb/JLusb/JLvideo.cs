using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.VFW;
using AForge.Video.FFMPEG;

namespace JLusb
{
    public class JLvideo
    {
        private JPEGStream mStream;
        private AVIWriter mAviWriter;
        private Bitmap mBitmap;
        public JLvideo()
        {
            // create JPEG video source
            mStream = new AForge.Video.JPEGStream();
            // set NewFrame event handler
            mStream.NewFrame += new AForge.Video.NewFrameEventHandler(video_NewFrame);
            // instantiate AVI writer, use WMV3 codec
            mAviWriter = new AVIWriter( "wmv3" );
        }
        public void set_Image(Bitmap bm)
        {
            mBitmap = bm;
        }
        public Bitmap get_Image()
        {
            return mBitmap;
        }
        public void Start()
        {
            //mStream.Start();
            // create new AVI file and open it
            mAviWriter.Open("test.avi", mBitmap.Width, mBitmap.Height);
            mAviWriter.AddFrame(mBitmap);
        }
        public void Stop()
        {
            //mStream.SignalToStop();
            mAviWriter.Close();
        }

        private void video_NewFrame( object sender, NewFrameEventArgs eventArgs )
        {
            // get new frame
            Bitmap bitmap = eventArgs.Frame;
            // process the frame
            // add the image as a new frame of video file
            mAviWriter.AddFrame(mBitmap);
        }
        private void delay(int coutn)
        {
            while (coutn-- > 0) ;
        }
        public void test()
        {
            int width = 320;
            int height = 240;
            // create instance of video writer
            VideoFileWriter writer = new VideoFileWriter();
            // create new video file
            writer.Open("test.avi", width, height, 25, VideoCodec.MPEG4);
            // create a bitmap to save into the video file
            Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            // write 1000 video frames
            for (int i = 0; i < 1000; i++)
            {
                image.SetPixel(i % width, i % height, Color.Red);
                writer.WriteVideoFrame(image);
            }
            writer.Close();
        }

        public void test_read()
        {
            // create instance of video reader
            VideoFileReader reader = new VideoFileReader();
            // open video file
            reader.Open("test.avi");
            // check some of its attributes
            Console.WriteLine("width:  " + reader.Width);
            Console.WriteLine("height: " + reader.Height);
            Console.WriteLine("fps:    " + reader.FrameRate);
            Console.WriteLine("codec:  " + reader.CodecName);
            // read 100 video frames out of it
            for (int i = 0; i < 100; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();
                // process the frame somehow
                // ...

                // dispose the frame when it is no longer required
                videoFrame.Dispose();
            }
            reader.Close();

        }
    }
}