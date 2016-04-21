using System;
using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class ucTramHistorieSCH : UserControl
    {
        private EyeCT4RailsLib.Tram _tram;

        public ucTramHistorieSCH(string tramnummer)
        {
            InitializeComponent();

            //test tram
            _tram = new Tram(Convert.ToInt32(tramnummer), EyeCT4RailsLib.Enums.Status.Dienst, new Line(0), false); 

            lblTramNummer.Text = "Tramnummer : " + _tram.Id;
        }
    }
}
