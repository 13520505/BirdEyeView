//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using Emgu.Util;
using BirdsEyeEngine;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Capture _capture;
        private Capture _capture2, _capture3, _capture4;
        private BirdsEye birdsEye, birdsEye2, birdsEye3, birdsEye4;

        public Form1()
        {
            InitializeComponent();

            //try to create the capture
            if (_capture == null)
            {
                try
                {
                    _capture = new Capture(1);
                }
                catch (NullReferenceException excpt)
                {   //show errors if there is any
                    MessageBox.Show(excpt.Message);
                }
            }
            if (_capture3 == null)
            {
                try
                {
                    _capture3 = new Capture(2);
                }
                catch (NullReferenceException excpt)
                {   //show errors if there is any
                    MessageBox.Show(excpt.Message);
                }
            }
            if (_capture2 == null)
            {
                try
                {
                    _capture2 = new Capture(0);
                }
                catch (NullReferenceException excpt)
                {   //show errors if there is any
                    MessageBox.Show(excpt.Message);
                }
            }
            if (_capture4 == null)
            {
                try
                {
                    _capture4 = new Capture(3);
                }
                catch (NullReferenceException excpt)
                {   //show errors if there is any
                    MessageBox.Show(excpt.Message);
                }
            }
            Image<Bgr, byte> RawImage = _capture.QueryFrame().ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage2 = _capture2.QueryFrame().ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage3 = _capture3.QueryFrame().ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage4 = _capture4.QueryFrame().ToImage<Bgr, byte>();
            double ALPHA = 30;				    // Degree
            int LENGTH = 800;			            // Pixels
            int h = RawImage.Height / 2;
            int temp = h;
            int srcTopY = h-temp ;

            birdsEye = new BirdsEye(ALPHA, LENGTH, srcTopY, RawImage.Width, RawImage.Height);
            birdsEye2 = new BirdsEye(ALPHA, LENGTH, srcTopY, RawImage2.Width, RawImage2.Height);
            birdsEye3 = new BirdsEye(ALPHA, LENGTH, srcTopY, RawImage3.Width, RawImage3.Height);
            birdsEye4 = new BirdsEye(ALPHA, LENGTH, srcTopY, RawImage4.Width, RawImage4.Height);
            if (_capture != null) //if camera capture has been successfully created
            {
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
            }
            if (_capture2 != null) //if camera capture has been successfully created
            {
                _capture2.ImageGrabbed += ProcessFrame;
                _capture2.Start();
            }
            if (_capture3 != null) //if camera capture has been successfully created
            {
                _capture3.ImageGrabbed += ProcessFrame;
                _capture3.Start();
            }
            if (_capture4 != null) //if camera capture has been successfully created
            {
                _capture4.ImageGrabbed += ProcessFrame;
                _capture4.Start();
            }
          
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Mat mat = new Mat();
            _capture.Retrieve(mat);
            Mat mat2 = new Mat();
            _capture2.Retrieve(mat2);
            Mat mat3 = new Mat();
            _capture3.Retrieve(mat3);
            Mat mat4 = new Mat();
            _capture4.Retrieve(mat4);

            Image<Bgr, byte> RawImage = mat.ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage2 = mat2.ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage3 = mat3.ToImage<Bgr, byte>();
            Image<Bgr, byte> RawImage4 = mat4.ToImage<Bgr, byte>();

            RawImage = RawImage.Convert<Bgr, byte>();
            RawImage2 = RawImage2.Convert<Bgr, byte>();
            RawImage3 = RawImage3.Convert<Bgr, byte>();
            RawImage4 = RawImage4.Convert<Bgr, byte>();
            Image<Bgr, byte> birdsEyeImage = birdsEye.BirdEyeTransform(RawImage);
            Image<Bgr, byte> birdsEyeImage2 = birdsEye2.BirdEyeTransform(RawImage2);
            Image<Bgr, byte> birdsEyeImage3 = birdsEye3.BirdEyeTransform(RawImage3);
            Image<Bgr, byte> birdsEyeImage4 = birdsEye4.BirdEyeTransform(RawImage4);
            capturedImageBox.Image = birdsEyeImage;
            //capturedImageBox.SetZoomScale(0.5, new Point(200, 200));
            forgroundImageBox.Image = birdsEyeImage;
            Cam2.Image = birdsEyeImage2.Rotate(90, new Bgr(System.Drawing.Color.Black), false);
            //Cam2.SetZoomScale(0.5, new Point(200, 200));

            imageTranformLeft.Image = birdsEyeImage2;
            double a = 180;
            Cam3.Image = birdsEyeImage3.Rotate(a, new Bgr(System.Drawing.Color.Red),false);
            //Cam3.SetZoomScale(0.5, new Point(400, 400));
            Cam4.Image = birdsEyeImage4.Rotate(-90, new Bgr(System.Drawing.Color.Blue),false);
            //Cam4.SetZoomScale(0.5, new Point(200, 200));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _capture.Stop();
        }

        private void Cam2_Click(object sender, EventArgs e)
        {

        }
    }
}
