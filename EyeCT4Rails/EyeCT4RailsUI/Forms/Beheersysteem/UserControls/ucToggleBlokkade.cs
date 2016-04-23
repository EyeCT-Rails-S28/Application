using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcToggleBlokkade : UserControl
    {
        public UcToggleBlokkade()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track, Section section)
        {
            tbSpoornummer.Text = track?.Id.ToString() ?? "";
            tbSectornummer.Text = section?.Id.ToString() ?? "";
        }
    }
}
