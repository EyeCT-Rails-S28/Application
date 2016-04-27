using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class UcReparatie : UserControl
    {
        public event EventHandler CelDoubleClicked;

        private List<MaintenanceJob> _schedule;

        public UcReparatie()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                _schedule = MaintenanceRepository.Instance.GetSchedule();

                dgvTrams.Rows.Clear();

                foreach (MaintenanceJob maintenanceJob in _schedule)
                {
                    dgvTrams.Rows.Add(false, maintenanceJob.Id, maintenanceJob.Tram.Id,
                        maintenanceJob.Tram.TramType.GetDescription(), maintenanceJob.Tram.PreferredLine.Id,
                        maintenanceJob.JobSize, maintenanceJob.Date.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show($"Fout bij herladen van data: {e.Message}");
            }
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CelDoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }

        private void btnReparatieAfronden_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrams.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    try
                    {
                        MaintenanceRepository.Instance.EditJobStatus(Convert.ToInt32(row.Cells[1].Value), true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show($"Fout bij het bewerken van status voor ID: {row.Cells[1].Value}, {ex.Message}");
                    } 
                }
            }

            RefreshData();
        }
    }
}
