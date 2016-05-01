using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcTramHistorieSch : UserControl
    {
        private List<Cleanup> _history;
         
        public UcTramHistorieSch()
        {
            InitializeComponent();

            try
            {
                _history = CleanupRepository.Instance.GetHistory();
                ShowHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het laden van het overzicht: {ex.Message}");
            }
        }

        public UcTramHistorieSch(int tramnummer)
        {
            InitializeComponent();

            try
            {
                _history = CleanupRepository.Instance.GetHistory(tramnummer);
                ShowHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het laden van het overzicht voor tram met ID: {tramnummer}, {ex.Message}");
            }
        }

        private void ShowHistory()
        {
            if (_history.Count > 0)
            {
                foreach (Cleanup cleanup in _history)
                {
                    dgvTramHistorie.Rows.Add(cleanup.Tram.Id, cleanup.Tram.TramType.GetDescription(), cleanup.JobSize.ToString(), cleanup.Date.ToString("dd/MM/yyyy"), cleanup.User.Name);
                }
            }
            else
            {
                MessageBox.Show($"Er zijn geen resultaten gevonden");
            }
        }
    }
}
