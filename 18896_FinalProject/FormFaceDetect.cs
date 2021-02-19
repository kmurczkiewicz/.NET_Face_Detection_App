using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;

namespace _18896_FinalProject
{
    public partial class FormFaceDetect : Form {

        private FaceDetectManager faceDetectManager = new FaceDetectManager();
        private FormGeneratedImage formGen = new FormGeneratedImage();

        public FormFaceDetect()
        {
            InitializeComponent();
            DesignManager.IndygoBack(this);
            DesignManager.YellowBackIndygoFore(buttonDetect, btnBack, btnSave, groupResolution, comboDetectionTarget, btnRandomHuman, btnRandomCat);
            DesignManager.HideElemetns(labelLiveImage, labelFace, btnSave, groupResolution, labelTarget, comboDetectionTarget);
            DesignManager.YellowFore(labelGenerate);
            labelTarget.ForeColor = Color.FromArgb(239, 212, 105);
            comboDetectionTarget.SelectedIndex = 0;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            faceDetectManager.SetVideoDevice(pickDevice);
            faceDetectManager.SetPictureBoxes(lastDetectedFace, camPlace);
        }

        private void buttonDetect_Click(object sender, EventArgs e)
        {
            faceDetectManager.DetectStart(labelLiveImage, labelFace, btnSave, groupResolution, radioHigh, labelTarget, comboDetectionTarget);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            faceDetectManager.StopDevice();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Hide();
            faceDetectManager.FaceDetectBack();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            faceDetectManager.SaveDetectedFace(radioHigh.Checked, radioMedium.Checked, radioLow.Checked);
        }

        private void comboDetectionTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            FaceDetectManager.SetDetectionTarget(comboDetectionTarget.SelectedIndex);
            Debug.WriteLine(comboDetectionTarget.SelectedIndex.ToString());
        }

        private void btnRandomCat_Click(object sender, EventArgs e)
        {
            showGeneratedForm("cat");
        }

        private void btnRandomHuman_Click(object sender, EventArgs e)
        {
            showGeneratedForm("human");
        }
        
        private void showGeneratedForm(string p)
        {
            if(p== "cat")
            {
                formGen.DownloadCat();
            }
            else if(p == "human")
            {
                formGen.DownloadHuman();
            }

            formGen.FormBorderStyle = FormBorderStyle.FixedSingle;
            formGen.MaximizeBox = false;
            formGen.Show();
        }
    }
}
