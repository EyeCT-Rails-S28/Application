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

        public UcTramHistorieSch(int tramnummer)
        {
            InitializeComponent();

            try
            {
                List<Cleanup> history = CleanupRepository.Instance.GetHistory(tramnummer);
                if (history.Count > 0)
                {
                    lblTramNummer.Text = "Tramnummer: " + history[0].Tram.Id;
                    lblSpoor.Text = "Spoor: " + history[0].Tram.PreferredLine;
                    lblSoort.Text = "Soort: " + history[0].Tram.TramType.GetDescription();

                    foreach (Cleanup cleanup in history)
                    {
                        dgvTramHistorie.Rows.Add(cleanup.JobSize.ToString(), cleanup.Date.ToString("dd/MM/yyyy"),
                            cleanup.User.Name);
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
                MessageBox.Show($"Fout bij het laden van het overzicht voor tram met ID: {tramnummer}, {ex.Message}");
            }
            
        }
    }
}
