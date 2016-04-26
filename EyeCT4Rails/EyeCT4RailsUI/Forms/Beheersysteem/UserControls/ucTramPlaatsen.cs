using System.Windows.Forms;
using EyeCT4RailsLib;

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
    }
}
