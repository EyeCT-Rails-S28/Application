using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcSchoonmaak : UserControl
    {
        public event EventHandler CelDoubleClicked;

        private List<Cleanup> _schedule;

        public UcSchoonmaak()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            _schedule = CleanupRepository.Instance.GetSchedule();

            dgvTrams.Rows.Clear();

            foreach (Cleanup cleanup in _schedule)
            {
                dgvTrams.Rows.Add(false, cleanup.Id, cleanup.Tram.Id, null, cleanup.Tram.PreferredLine.Id, cleanup.JobSize, Convert.ToString(cleanup.Date));
            }
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CelDoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }

        private void btnSchoonmaakbeurtAfronden_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrams.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    CleanupRepository.Instance.EditJobStatus(Convert.ToInt32(row.Cells[1].Value), true);
                }
            }

            RefreshData();
        }
    }
}
