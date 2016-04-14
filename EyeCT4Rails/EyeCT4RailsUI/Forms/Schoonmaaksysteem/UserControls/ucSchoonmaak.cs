using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class ucSchoonmaak : UserControl
    {
        public event EventHandler StatusUpdated;

        public ucSchoonmaak()
        {
            InitializeComponent();
        }

        private void FunctionThatRaisesEvent()
        {
            StatusUpdated?.Invoke(dgvTrams, new EventArgs());
        }

        private void dgvTrams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FunctionThatRaisesEvent();
        }
    }
}
