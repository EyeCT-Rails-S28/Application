using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class UcTramHistorieRs : UserControl
    {
        private List<MaintenanceJob> _history;
         
        public UcTramHistorieRs()
        {
            InitializeComponent();

            try
            {
                _history = MaintenanceRepository.Instance.GetHistory();
                ShowHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het toevoegen van items: {ex.Message}");
            }
        }

        public UcTramHistorieRs(int tramnummer)
        {
            InitializeComponent();

            try
            {
                _history = MaintenanceRepository.Instance.GetHistory(tramnummer);
                ShowHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het toevoegen van items: {ex.Message}");
            }
        }

        private void ShowHistory()
        {
            if (_history.Count > 0)
            {
                foreach (MaintenanceJob maintenanceJob in _history)
                {
                    dgvTramHistorie.Rows.Add(maintenanceJob.Tram.Id, maintenanceJob.Tram.TramType.GetDescription(), maintenanceJob.JobSize.ToString(),
                        maintenanceJob.Date.ToString("dd/MM/yyyy"), maintenanceJob.User.Name);
                }
            }
            else
            {
                MessageBox.Show($"Er zijn geen resultaten gevonden");
            }
        }
    }
}
