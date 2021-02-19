using System.Drawing;
using System.Windows.Forms;

namespace _18896_FinalProject
{
    class DesignManager
    {
        private static Color indygo = Color.FromArgb(9, 49, 69), 
            yellow = Color.FromArgb(239, 212, 105);
             
        public static void YellowBackIndygoFore(params Control[] list)
        {
            foreach(Control c in list)
            {
                c.BackColor = yellow;
                c.ForeColor = indygo;
            }
        }

        public static void HideElemetns(params Control[] list)
        {
            foreach (Control c in list)
            {
                c.Hide();
            }
        }

        public static void ShowElemetns(params Control[] list)
        {
            foreach (Control c in list)
            {
                c.Show();
            }
        }

        public static void IndygoBack(Control c)
        {
            c.BackColor = indygo;
        }

        public static void YellowFore(params Control[] list)
        {
            foreach (Control c in list)
            {
                c.ForeColor = yellow;
            }
        }
    }
}
