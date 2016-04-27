using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
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
            _schedule = MaintenanceRepository.Instance.GetSchedule();

            dgvTrams.Rows.Clear();

            foreach (MaintenanceJob maintenanceJob in _schedule)
            {
                dgvTrams.Rows.Add(false, maintenanceJob.Id, maintenanceJob.Tram.Id, null, maintenanceJob.Tram.PreferredLine.Id, maintenanceJob.JobSize, Convert.ToString(maintenanceJob.Date));
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
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    int maintenanceId = Convert.ToInt32(row.Cells[1].Value);

                    MaintenanceRepository.Instance.EditJobStatus(maintenanceId, true);

                    RefreshData();
                    break;
                }
            }
        }
    }
}
