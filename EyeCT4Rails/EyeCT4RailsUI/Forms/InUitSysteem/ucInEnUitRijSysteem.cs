using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.InUitSysteem
{
    public partial class UcInEnUitRijSysteem : UserControl
    {
        public UcInEnUitRijSysteem()
        {
            InitializeComponent();
        }

        private void btnBevestig_Click(object sender, EventArgs e)
        {
            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                string nummer = tbTramnummer.Text;
                int tramId = Convert.ToInt32(nummer);
                Track track = depot.Tracks.Find(t => t.Sections.Find(s => s.Tram?.Id == tramId) != null);
                Section section = null;

                if (string.IsNullOrWhiteSpace(nummer))
                {
                    MessageBox.Show("Tram ID mag niet leeg zijn.");
                }
                else if (!depot.Trams.Exists(t => t.Id == tramId))
                {
                    MessageBox.Show($"Tram met ID: {tramId} bestaat niet.");
                }
                else if (track != null)
                {
                    section = track.Sections.Find(s => s.Tram?.Id == tramId);
                    if (section.Tram.Status == Status.Dienst)
                    {
                        RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Remise);
                    }
                }
                else if (rbDefect.Checked)
                {
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Gereserveerd);
                    tbTramnummer.ReadOnly = true;
                    timer.Start();

                    MessageBox.Show("Er is een speciale actie vereist van een beheerder, wacht op instructies.");
                }
                else
                {
                    section = RideManagementRepository.Instance.GetFreeSection(depot, depot.Trams.Find(t => t.Id == tramId).TramType);
                    track = depot.Tracks.Find(t => t.Sections.Find(s => s.Id == section.Id) != null);

                    if (track == null)
                    {
                        MessageBox.Show($"Fout bij ophalen van het spoornummer.");
                        return;
                    }

                    DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, rbGeen.Checked ? Status.Remise : Status.Schoonmaak);
                }

                tbSpoornummer.Text = Convert.ToString(track?.Id);
                tbSectienummer.Text = Convert.ToString(section?.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het bevestigen van het tramnummer: {ex.Message}");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Tram tram = depot.Trams.Find(t => t.Id == Convert.ToInt32(tbTramnummer.Text));

            if (tram != null && tram.Status != Status.Gereserveerd)
            {
                timer.Stop();
                tbTramnummer.ReadOnly = false;

                Track track = depot.Tracks.Find(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tram.Id) != null);
                Section section = track.Sections.Find(s => s.Tram != null && s.Tram.Id == tram.Id);

                tbSpoornummer.Text = Convert.ToString(track.Id);
                tbSectienummer.Text = Convert.ToString(section.Id);
            }
        }
    }
}
