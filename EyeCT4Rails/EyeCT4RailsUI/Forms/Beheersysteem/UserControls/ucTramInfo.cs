using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcTramInfo : UserControl
    {
        public UcTramInfo()
        {
            InitializeComponent();

            List<Tram> trams = DepotManagementRepository.Instance.GetAllTrams();
            foreach (Tram tram in trams)
            {
                dataGridView1.Rows.Add(tram.Id, tram.PreferredLine.Id, null, tram.Status.ToString(), null, null, null);
            }
        }
    }
}
