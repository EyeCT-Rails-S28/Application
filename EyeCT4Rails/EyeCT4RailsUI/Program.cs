using System;
using System.Windows.Forms;
using EyeCT4RailsUI.Forms.Beheersysteem;

namespace EyeCT4RailsUI
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
            Application.Run(new FrmBs());
        }
    }
}
