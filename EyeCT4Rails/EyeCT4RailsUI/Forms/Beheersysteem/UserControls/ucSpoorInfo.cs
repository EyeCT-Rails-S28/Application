using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcSpoorInfo : UserControl
    {
        private List<Tram> _trams;

        public UcSpoorInfo()
        {
            InitializeComponent();

            _trams = DepotManagementRepository.Instance.GetAllTrams();
        }

        public void SetSelection(Track track)
        {
            nudSpoornummer.Value = track?.Id ?? 0;
        }

        private void btnShow_Click(object sender, System.EventArgs e)
        {
            try
            {
                Tram tram = _trams.Find(t => t.Id == Convert.ToInt32(nudSpoornummer.Value));

                if (tram != null)
                {
                    rtbTramInfo.Text = $"Id: {tram.Id} Status: {tram.Status} Line: {tram.PreferredLine}";
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
