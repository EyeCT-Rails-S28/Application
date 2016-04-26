using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcToggleBlokkade : UserControl
    {
        private Depot _depot;

        public UcToggleBlokkade()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track, Section section, Depot depot)
        {
            nudSpoornummer.Value = track?.Id ?? 0;
            nudSectornummer.Value = section?.Id ?? -1;

            _depot = depot;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            int trackId = Convert.ToInt32(nudSpoornummer.Value);
            int sectionId = Convert.ToInt32(nudSectornummer.Value);

            try
            {
                DepotManagementRepository.Instance.SetTrackBlocked(trackId, !_depot.Tracks[trackId].Sections.Any(x => x.Blocked));

                if (sectionId >= 0)
                    DepotManagementRepository.Instance.SetSectionBlocked(sectionId, !_depot.Tracks[trackId].Sections[sectionId].Blocked);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
