using System;
using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcTramHistorieSch : UserControl
    {
        public UcTramHistorieSch(string tramnummer)
        {
            InitializeComponent();

            //test tram
            Tram tram = new Tram(Convert.ToInt32(tramnummer), EyeCT4RailsLib.Enums.Status.Dienst, new Line(0), false); 

            lblTramNummer.Text = "Tramnummer : " + tram.Id;
        }
    }
}
