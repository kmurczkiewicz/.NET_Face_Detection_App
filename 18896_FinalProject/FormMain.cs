using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    public partial class FormMain : Form
    {
        //private FormFaceDetect//
        private FormFaceDetect faceForm;
        public FormMain()
        {
            InitializeComponent();

            faceForm = new FormFaceDetect();
            faceForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            faceForm.MaximizeBox = false;

            DesignManager.IndygoBack(this);
            DesignManager.YellowBackIndygoFore(btnFace, btnLoad, btnExit);
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            Hide();
            faceForm.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new FormDecode();
            form1.FormBorderStyle = FormBorderStyle.FixedSingle;
            form1.MaximizeBox = false;
            form1.Closed += (s, args) => Close();
            form1.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
