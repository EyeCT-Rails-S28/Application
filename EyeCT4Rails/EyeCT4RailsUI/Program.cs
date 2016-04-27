using System;
using System.Windows.Forms;
using EyeCT4RailsLogic;
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
            DepotManagementRepository.Instance.UpdateSections();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBs());
        }
    }
}
