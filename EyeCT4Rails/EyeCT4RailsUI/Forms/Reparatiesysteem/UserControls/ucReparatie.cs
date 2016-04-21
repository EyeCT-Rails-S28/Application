using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class UcReparatie : UserControl
    {
        public event EventHandler CelDoubleClicked;

        public UcReparatie()
        {
            InitializeComponent();
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CelDoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }
    }
}
