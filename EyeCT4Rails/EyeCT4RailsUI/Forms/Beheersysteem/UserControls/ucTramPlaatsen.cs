using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcTramPlaatsen : UserControl
    {
        public UcTramPlaatsen()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track, Section section)
        {
            nudSpoornummer.Value = track?.Id ?? 0;
            nudSectornummer.Value = section?.Id ?? 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DepotManagementRepository.Instance.ReserveSection(Convert.ToInt32(nudTramnummer.Value), Convert.ToInt32(nudSectornummer.Value));
        }
    }
}
