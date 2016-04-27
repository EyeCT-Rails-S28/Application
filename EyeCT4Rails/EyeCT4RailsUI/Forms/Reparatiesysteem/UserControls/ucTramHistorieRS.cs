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
        public UcTramHistorieRs(int tramnummer)
        {
            InitializeComponent();

            try
            {
                List<MaintenanceJob> history = MaintenanceRepository.Instance.GetHistory(tramnummer);

                if (history.Count > 0)
                {
                    lblTramNummer.Text = "Tramnummer: " + history[0].Tram.Id;
                    lblSpoor.Text = "Spoor: " + history[0].Tram.PreferredLine;
                    lblSoort.Text = "Soort: " + history[0].Tram.TramType.GetDescription();

                    foreach (MaintenanceJob maintenanceJob in history)
                    {
                        dgvTramHistorie.Rows.Add(maintenanceJob.JobSize.ToString(),
                            maintenanceJob.Date.ToString("dd/MM/yyyy"), maintenanceJob.User.Name);
                    }
                }
                else
                {
                    MessageBox.Show($"Er zijn geen resultaten gevonden voor tramnummer: {tramnummer}");
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
