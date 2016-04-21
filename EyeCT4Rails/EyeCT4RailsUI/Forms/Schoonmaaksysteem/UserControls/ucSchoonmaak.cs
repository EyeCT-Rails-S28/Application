using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcSchoonmaak : UserControl
    {
        public event EventHandler CelDoubleClicked;

        public UcSchoonmaak()
        {
            InitializeComponent();
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CelDoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }
    }
}
