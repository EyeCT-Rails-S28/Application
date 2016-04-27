using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcTramHistorieSch : UserControl
    {

        private List<Cleanup> _history;

        public UcTramHistorieSch(string tramnummer)
        {
            InitializeComponent();

            //_history = CleanupRepository.Instance.
            //Tram tram = new Tram(Convert.ToInt32(tramnummer), EyeCT4RailsLib.Enums.Status.Dienst, new Line(0), false); 

            //lblTramNummer.Text = "Tramnummer : " + tram.Id;
        }
    }
}
