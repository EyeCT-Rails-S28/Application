using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcTramVerwijderen : UserControl
    {
        public UcTramVerwijderen()
        {
            InitializeComponent();
        }

        public void SetSelection(Section section)
        {
            nudSectornummer.Value = section?.Id ?? 0;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            DepotManagementRepository.Instance.RemoveTram(Convert.ToInt32(nudSectornummer.Value));
        }
    }
}
