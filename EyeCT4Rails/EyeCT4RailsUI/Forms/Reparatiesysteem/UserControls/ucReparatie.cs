using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class ucReparatie : UserControl
    {
        public event EventHandler Cel_DoubleClicked;

        public ucReparatie()
        {
            InitializeComponent();
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cel_DoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }
    }
}
