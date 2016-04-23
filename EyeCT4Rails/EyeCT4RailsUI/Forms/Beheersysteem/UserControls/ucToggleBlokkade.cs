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
            tbSpoornummer.Text = track?.Id.ToString() ?? "";
            tbSectornummer.Text = section?.Id.ToString() ?? "";

            _depot = depot;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            int trackId = Convert.ToInt32(tbSpoornummer.Text);
            int sectionId = Convert.ToInt32(tbSectornummer.Text);

            if (tbSpoornummer.Text != "")
            {
                DepotManagementRepository.Instance.SetTrackBlocked(new Track(trackId), !_depot.Tracks[trackId].Sections.Any(x => x.Blocked));

                if (tbSectornummer.Text != "")
                    DepotManagementRepository.Instance.SetSectionBlocked(new Section(sectionId, true), !_depot.Tracks[trackId].Sections[sectionId].Blocked);
            }
        }
    }
}
