using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
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
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                _schedule = CleanupRepository.Instance.GetSchedule();
                Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to fetch the schedule.");

                dgvTrams.Rows.Clear();

                foreach (Cleanup cleanup in _schedule)
                {
                    dgvTrams.Rows.Add(false, cleanup.Id, cleanup.Tram.Id, cleanup.Tram.TramType.GetDescription(),
                        cleanup.Tram.PreferredLine.Id, cleanup.JobSize, cleanup.Date.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show($"Fout bij het herladen van data: {e.Message}");
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
                    try
                    {
                        CleanupRepository.Instance.EditJobStatus(Convert.ToInt32(row.Cells[1].Value), true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show($"Fout bij het afronden van schoonmaakbeurt met ID: {row.Cells[1].Value}, {ex.Message}");
                    }
                }
            }

            RefreshData();
        }
    }
}
