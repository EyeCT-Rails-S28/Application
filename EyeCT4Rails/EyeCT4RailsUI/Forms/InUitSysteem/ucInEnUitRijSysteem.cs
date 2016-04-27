using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.InUitSysteem
{
    public partial class UcInEnUitRijSysteem : UserControl
    {
        private Depot _depot;

        public UcInEnUitRijSysteem()
        {
            InitializeComponent();
        }

        public void SetDepot(Depot depot)
        {
            _depot = depot;
        }

        private void btnBevestig_Click(object sender, System.EventArgs e)
        {
            try
            {
                string nummer = tbTramnummer.Text;
                if (string.IsNullOrWhiteSpace(nummer))
                {
                    MessageBox.Show("Tram ID mag niet leeg zijn.");
                    return;
                }

                int tramId = Convert.ToInt32(nummer);
                if (!_depot.Trams.Exists(t => t.Id == tramId))
                {
                    MessageBox.Show($"Tram met ID: {tramId} bestaat niet.");
                    return;
                }

                Section section = RideManagementRepository.Instance.GetFreeSection(_depot);
                Track track = _depot.Tracks.Find(t => t.Sections.Find(s => s.Id == section.Id) != null);

                if (track == null)
                {
                    MessageBox.Show($"Fout bij ophalen van het spoornummer.");
                    return;
                }

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
