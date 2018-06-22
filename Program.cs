using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataScrambler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login _lf = new Login();
            if (_lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new ScramblerMain());
            }
        }

    }
}