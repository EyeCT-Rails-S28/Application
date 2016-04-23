using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcReserveringPlaatsen : UserControl
    {
        public UcReserveringPlaatsen()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track)
        {
            tbSpoornummer.Text = track?.Id.ToString() ?? "";
        }
    }
}
