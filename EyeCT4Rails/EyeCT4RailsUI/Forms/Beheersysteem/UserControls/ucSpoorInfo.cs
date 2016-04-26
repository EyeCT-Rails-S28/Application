using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcSpoorInfo : UserControl
    {
        public UcSpoorInfo()
        {
            InitializeComponent();
        }

        public void SetSelection(Track track)
        {
            nudSpoornummer.Value = track?.Id ?? 0;
        }
    }
}
