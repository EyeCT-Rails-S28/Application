using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcSpoorInfo : UserControl
    {
        private Depot _depot;

        public UcSpoorInfo()
        {
            InitializeComponent();

            _depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
        }

        public void SetSelection(Track track)
        {
            nudSpoornummer.Value = track?.Id ?? 0;
        }

        private void btnShow_Click(object sender, System.EventArgs e)
        {
            try
            {
                Track track = _depot.Tracks.Find(t => t.Id == Convert.ToInt32(nudSpoornummer.Value));

                if (track != null)
                {
                    rtbTramInfo.Text = $"Spoor ID: {track.Id}";

                    foreach (Section section in track.Sections)
                    {
                        rtbTramInfo.Text += Environment.NewLine + $"Section ID: {section.Id} IsBlocked: {section.Blocked} Tram ID: {section.Tram.Id}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
