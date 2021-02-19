using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    public partial class FormDecode : Form
    {
        private FileManager fileManager = new FileManager();

        public FormDecode()
        {
            InitializeComponent();
            DesignManager.IndygoBack(this);
            DesignManager.YellowBackIndygoFore(btnSelect, btnBack, btnLeft, btnRight);
            DesignManager.YellowFore(labelResolution, labelDateSet, labelResolutionSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileManager.OpenFileAndDecodeImages(decodedPictureBox, labelImageInfo, labelResolutionSet, labelDateSet);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fileManager.FormDecodeBack();
            Hide();
            var form1 = new FormMain();
            form1.Closed += (s, args) => Close();
            form1.Show();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            fileManager.PickNextEncodedImageLeft(decodedPictureBox, labelImageInfo, labelDateSet, labelResolutionSet);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            fileManager.PickNextEncodedImageRight(decodedPictureBox, labelImageInfo, labelDateSet, labelResolutionSet);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            fileManager.ImageExport();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fileManager.DeleteDecodedImage(decodedPictureBox);
        }
    }
}
