using System;
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
                if (string.IsNullOrWhiteSpace(nummer))
                {
                    MessageBox.Show("Tram ID mag niet leeg zijn.");
                    return;
                }

                int tramId = Convert.ToInt32(nummer);
                if (!depot.Trams.Exists(t => t.Id == tramId))
                {
                    MessageBox.Show($"Tram met ID: {tramId} bestaat niet.");
                    return;
                }

                Stopwatch watch = new Stopwatch();
                watch.Start();

                Section section = RideManagementRepository.Instance.GetFreeSection(depot);
                Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to find a free section.");

                Track track = depot.Tracks.Find(t => t.Sections.Find(s => s.Id == section.Id) != null);

                if (track == null)
                {
                    MessageBox.Show($"Fout bij ophalen van het spoornummer.");
                    return;
                }

                watch.Restart();
                DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);
                Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to reserve a section.");

                watch.Restart();
                RideManagementRepository.Instance.ChangeTramStatus(tramId, rbGeen.Checked ? Status.Remise : rbDefect.Checked ? Status.Gereserveerd : Status.Schoonmaak);
                Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to change a trams status.");

                tbSpoornummer.Text = Convert.ToString(track.Id);
                tbSectienummer.Text = Convert.ToString(section.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij het bevestigen van het tramnummer: {ex.Message}");
            }
        }
    }
}
