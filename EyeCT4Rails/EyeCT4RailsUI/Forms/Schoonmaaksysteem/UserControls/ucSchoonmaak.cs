using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class ucSchoonmaak : UserControl
    {
        public event EventHandler Cel_DoubleClicked;

        public ucSchoonmaak()
        {
            InitializeComponent();
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cel_DoubleClicked?.Invoke(dgvTrams, new EventArgs());
        }
    }
}
