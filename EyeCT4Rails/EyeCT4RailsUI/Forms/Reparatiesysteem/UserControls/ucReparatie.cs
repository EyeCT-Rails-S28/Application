using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class ucReparatie : UserControl
    {
        public event EventHandler Cel_DubbleClicked;

        public ucReparatie()
        {
            InitializeComponent();
        }

        private void FunctionThatRaisesEvent()
        {
            Cel_DubbleClicked?.Invoke(dgvTrams, new EventArgs());
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FunctionThatRaisesEvent();
        }
    }
}
