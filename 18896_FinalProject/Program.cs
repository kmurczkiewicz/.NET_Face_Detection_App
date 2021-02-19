using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static FormMain mainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new FormMain();
            mainForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mainForm.MaximizeBox = false;
            Application.Run(mainForm);  
        }
    }
}
