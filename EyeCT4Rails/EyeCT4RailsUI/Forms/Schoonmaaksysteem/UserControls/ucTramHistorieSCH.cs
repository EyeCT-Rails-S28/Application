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

            try
            {
                _history = CleanupRepository.Instance.GetHistory(Convert.ToInt32(tramnummer));

                lblTramNummer.Text = "Tramnummer : " + _history[0].Tram.Id;
                lblSpoor.Text = "Spoor: " + _history[0].Tram.PreferredLine;

                foreach (Cleanup cleanup in _history)
                {
                    dgvTramHistorie.Rows.Add(cleanup.JobSize.ToString(), cleanup.Date.ToString(), null, cleanup.User.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
