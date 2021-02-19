using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    class FaceDetectManager
    {
        FilterInfoCollection myFilter;
        VideoCaptureDevice myDevice;

        static readonly CascadeClassifier faceClassifier = new CascadeClassifier("trainingDataSet_Face.xml");
        static readonly CascadeClassifier eyeClassifier = new CascadeClassifier("trainingDataSet_Eyes.xml");
        static readonly CascadeClassifier catClassifier = new CascadeClassifier("trainingDataSet_CatFace.xml");

        Bitmap tmpBitmap;
        private static bool canSave = true;
        private ComboBox pickDevice;

        private PictureBox lastDetectedFace, camPlace;
        private Button btnSave;

        private static int detectionTarget;

        Font drawFont = new Font("Verdana", 24, FontStyle.Bold);
        
        public static void SetDetectionTarget(int dt)
        {
            detectionTarget = dt;
        }

        public void SetVideoDevice(ComboBox pickDevice) {
            this.pickDevice = pickDevice;
            myFilter = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo singleDevice in myFilter)
                pickDevice.Items.Add(singleDevice.Name);

            pickDevice.SelectedIndex = 0;

            myDevice = new VideoCaptureDevice();
        }

        public void SetPictureBoxes(PictureBox lastDetectedFace, PictureBox camPlace)
        {
            this.lastDetectedFace = lastDetectedFace;
            this.camPlace = camPlace;
        }

        public void DetectStart(Label labelLiveImage, Label labelFace, Button btnSave, GroupBox groupResolution, RadioButton radioHigh, Label labelTarget, ComboBox comboDetection)
        {
            detectionTarget = comboDetection.SelectedIndex;

            this.btnSave = btnSave;
            myDevice = new VideoCaptureDevice(myFilter[pickDevice.SelectedIndex].MonikerString);
            myDevice.NewFrame += Device_NewFrame;
            myDevice.Start();
            DesignManager.ShowElemetns(labelLiveImage, labelFace, btnSave, groupResolution, labelTarget, comboDetection);
            labelLiveImage.ForeColor = Color.FromArgb(239, 212, 105);
            labelFace.ForeColor = Color.FromArgb(239, 212, 105);
            radioHigh.Checked = true;
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs e)
        {
            switch (detectionTarget)
            {
                //Human faces
                case 0:
                    Bitmap bitmap_face = (Bitmap)e.Frame.Clone();
                    Image<Bgr, byte> grayImage_face = new Image<Bgr, byte>(bitmap_face);
                    Rectangle[] faces = faceClassifier.DetectMultiScale(grayImage_face, 1.2, 1);
                    foreach (Rectangle face in faces)
                    {
                        using (Graphics g = Graphics.FromImage(bitmap_face))
                        {
                            using (Pen pen = new Pen(Color.Blue, 5))
                            {
                                g.DrawRectangle(pen, face);
                                //Draw text under rectangle
                                drawFont = new Font("Verdana", 24, FontStyle.Bold);
                                Point p = new Point(face.Left + face.Width / 3, face.Top + face.Height);
                                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                                g.DrawString("Human", drawFont, drawBrush, p);

                                //Send bitmap to new window
                                tmpBitmap = (Bitmap)bitmap_face.Clone();
                                lastDetectedFace.Image = tmpBitmap;

                                DesignManager.YellowBackIndygoFore(btnSave);
                                canSave = true;
                            }
                        }
                    }
                    camPlace.Image = bitmap_face;
                    break;

                //Human faces with eyes
                case 1:
                    Bitmap bitmap_face_eyes = (Bitmap)e.Frame.Clone();
                    Image<Bgr, byte> grayImage_face_eyes = new Image<Bgr, byte>(bitmap_face_eyes);
                    Rectangle[] faces_with_eyes = faceClassifier.DetectMultiScale(grayImage_face_eyes, 1.2, 1);
                    foreach (Rectangle face in faces_with_eyes)
                    {
                        using (Graphics g = Graphics.FromImage(bitmap_face_eyes))
                        {

                            using (Pen pen = new Pen(Color.Magenta, 3))
                            {
                                Rectangle[] eyes = eyeClassifier.DetectMultiScale(grayImage_face_eyes, 1.2, 1);
                                foreach (Rectangle eye in eyes)
                                {
                                    g.DrawRectangle(pen, eye);
                                    drawFont = new Font("Verdana", 16, FontStyle.Bold);
                                    Point p = new Point(eye.Left + eye.Width / 3, eye.Top + eye.Height);
                                    SolidBrush drawBrush = new SolidBrush(Color.Magenta);
                                    g.DrawString("Eye", drawFont, drawBrush, p);
                                }
                            }

                            using (Pen pen = new Pen(Color.Blue, 5))
                            {
                                g.DrawRectangle(pen, face);
                                //Draw Text
                                drawFont = new Font("Verdana", 24, FontStyle.Bold);
                                Point p = new Point(face.Left + face.Width / 3, face.Top + face.Height);
                                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                                g.DrawString("Human", drawFont, drawBrush, p);
                                //Send bitmap to new window
                                tmpBitmap = (Bitmap)bitmap_face_eyes.Clone();
                                lastDetectedFace.Image = tmpBitmap;

                                DesignManager.YellowBackIndygoFore(btnSave);
                                canSave = true;
                            }
                        }
                    }
                    camPlace.Image = bitmap_face_eyes;
                    break;

                //Eyes only
                case 2:
                    Bitmap bitmap_eyes = (Bitmap)e.Frame.Clone();
                    Image<Bgr, byte> grayImage_eyes = new Image<Bgr, byte>(bitmap_eyes);
                    Rectangle[] eyes_arr = eyeClassifier.DetectMultiScale(grayImage_eyes, 1.2, 1);
                    foreach (Rectangle eye in eyes_arr)
                    {
                        using (Graphics g = Graphics.FromImage(bitmap_eyes))
                        {
                            using (Pen pen = new Pen(Color.Magenta, 3))
                            {
                                g.DrawRectangle(pen, eye);
                                //Draw text under rectangle
                                drawFont = new Font("Verdana", 24, FontStyle.Bold);
                                Point p = new Point(eye.Left + eye.Width / 3, eye.Top + eye.Height);
                                SolidBrush drawBrush = new SolidBrush(Color.Magenta);
                                g.DrawString("Eye", drawFont, drawBrush, p);

                                //Send bitmap to new window
                                tmpBitmap = (Bitmap)bitmap_eyes.Clone();
                                lastDetectedFace.Image = tmpBitmap;

                                DesignManager.YellowBackIndygoFore(btnSave);
                                canSave = true;
                            }
                        }
                    }
                    camPlace.Image = bitmap_eyes;
                    break;


                //Cat faces
                case 3:
                    Bitmap bitmap_cat = (Bitmap)e.Frame.Clone();
                    Image<Bgr, byte> grayImage_cat = new Image<Bgr, byte>(bitmap_cat);
                    Rectangle[] cats = catClassifier.DetectMultiScale(grayImage_cat, 1.2, 1);
                    foreach (Rectangle cat in cats)
                    {
                        using (Graphics g = Graphics.FromImage(bitmap_cat))
                        {
                            using (Pen pen = new Pen(Color.Cyan, 5))
                            {
                                g.DrawRectangle(pen, cat);

                                //Draw text under rectangle
                                drawFont = new Font("Verdana", 24, FontStyle.Bold);
                                Point p  = new Point(cat.Left + cat.Width/3, cat.Top + cat.Height); 
                                SolidBrush drawBrush = new SolidBrush(Color.Cyan);
                                g.DrawString("Cat", drawFont, drawBrush, p);

                                //Send bitmap to new window
                                tmpBitmap = (Bitmap)bitmap_cat.Clone();
                                lastDetectedFace.Image = tmpBitmap;

                                DesignManager.YellowBackIndygoFore(btnSave);
                                canSave = true;
                            }
                        }
                    }
                    camPlace.Image = bitmap_cat;
                    break;
            }
        }

        public void StopDevice()
        {
            if (myDevice.IsRunning)
            {
                myDevice.Stop();
            }
        }

        public void FaceDetectBack()
        {
            myDevice.Stop();
            Program.mainForm.Show();
        }

        public void SaveDetectedFace(bool high, bool medium, bool low)
        {
            if (tmpBitmap != null && canSave)
            {
                canSave = false;
                btnSave.BackColor = Color.Gray;
                btnSave.ForeColor = Color.White;
                //get value from radio buttons
                bool[] radioValues = {high, medium, low};

                FileManager fileManager = new FileManager();
                fileManager.EncodeAndSaveImage((Bitmap)tmpBitmap.Clone(), radioValues);
            }
        }

    }
}
