using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4RailsUI.Forms.Beheersysteem;
using EyeCT4RailsUI.Forms.Reparatiesysteem;
using EyeCT4RailsUI.Forms.Schoonmaaksysteem;

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
            Application.Run(new frmBS());
        }
    }
}
