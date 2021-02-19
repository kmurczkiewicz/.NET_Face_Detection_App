using System;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    public partial class FormGeneratedImage : Form
    {
        NetworkManager networkManager = new NetworkManager();

        public FormGeneratedImage()
        {
            InitializeComponent();

            DesignManager.IndygoBack(this);
            DesignManager.YellowBackIndygoFore(btnExit);

            labelDownload.BackColor = System.Drawing.Color.FromArgb(6, 176, 37);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void DownloadCat()
        {
            networkManager.GetGeneratedCat(labelDownload, downloadBar, generatedImage);
        }

        public void DownloadHuman()
        {
            networkManager.GetGeneratedHuman(labelDownload, downloadBar, generatedImage);
        }
    }
}
