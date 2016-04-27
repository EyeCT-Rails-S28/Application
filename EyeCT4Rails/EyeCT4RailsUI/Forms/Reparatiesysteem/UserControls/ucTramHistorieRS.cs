using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class UcTramHistorieRs : UserControl
    {
        private List<MaintenanceJob> _history;

        public UcTramHistorieRs(string tramnummer)
        {
            InitializeComponent();

            try
            {
                _history = MaintenanceRepository.Instance.GetHistory(Convert.ToInt32(tramnummer));

                lblTramNummer.Text = "Tramnummer : " + _history[0].Tram.Id;
                lblSpoor.Text = "Spoor: " + _history[0].Tram.PreferredLine;

                foreach (MaintenanceJob maintenanceJob in _history)
                {
                    dgvTramHistorie.Rows.Add(maintenanceJob.JobSize.ToString(), maintenanceJob.Date.ToString("dd/MM/yyyy HH:mm:ss"), maintenanceJob.User.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het toevoegen van items: {ex.Message}");
            }

        }
    }
}
