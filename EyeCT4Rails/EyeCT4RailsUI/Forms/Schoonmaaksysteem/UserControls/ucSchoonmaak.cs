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

        private List<Tram> _trams;

        public UcSchoonmaak()
        {
            InitializeComponent();

            _trams = CleanupRepository.Instance.GetDirtyTrams();

            DataGridViewRow row = (DataGridViewRow)dgvTrams.Rows[0].Clone();

            foreach (var tram in _trams)
            {
                row.Cells[0].Value = false;
                row.Cells[1].Value = tram.Id.ToString();
                dgvTrams.Rows.Add(row);
            }
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CelDoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }
    }
}
