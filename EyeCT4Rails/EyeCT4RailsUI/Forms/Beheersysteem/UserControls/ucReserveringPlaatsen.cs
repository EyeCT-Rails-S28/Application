using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcReserveringPlaatsen : UserControl
    {
        private Depot _depot;

        public UcReserveringPlaatsen()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track, Depot depot)
        {
            nudSectornummer.Value = track?.Id ?? 0;

            _depot = depot;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            int tramId = Convert.ToInt32(nudTramnummer.Value);
            int sectionId = Convert.ToInt32(nudSectornummer.Value);

            try
            {
                DepotManagementRepository.Instance.ReserveSection(tramId, sectionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
