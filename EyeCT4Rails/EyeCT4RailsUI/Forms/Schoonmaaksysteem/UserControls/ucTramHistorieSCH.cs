using System;
using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcTramHistorieSch : UserControl
    {
        private readonly EyeCT4RailsLib.Tram _tram;

        public UcTramHistorieSch(string tramnummer)
        {
            InitializeComponent();

            //test tram
            _tram = new Tram(Convert.ToInt32(tramnummer), EyeCT4RailsLib.Enums.Status.Dienst, new Line(0), false); 

            lblTramNummer.Text = "Tramnummer : " + _tram.Id;
        }
    }
}
