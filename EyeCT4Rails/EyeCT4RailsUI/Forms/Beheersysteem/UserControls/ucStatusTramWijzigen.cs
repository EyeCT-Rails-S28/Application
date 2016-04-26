using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcStatusTramWijzigen : UserControl
    {
        public UcStatusTramWijzigen()
        {
            InitializeComponent();

            foreach (Status status in Enum.GetValues(typeof(Status)))
            {
                cbStatus.Items.Add(status.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int tramId = Convert.ToInt32(nudTramnummer.Value);
                Status tramStatus = (Status)Enum.Parse(typeof(Status), cbStatus.Text);

                DepotManagementRepository.Instance.ChangeTramStatus(tramId, tramStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
