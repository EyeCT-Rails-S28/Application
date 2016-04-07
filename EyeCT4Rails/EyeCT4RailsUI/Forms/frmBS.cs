using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4RailsUI
{
    public partial class frmBs : Form
    {
        public frmBs()
        {
            InitializeComponent();
        }

        private void frmBs_Resize(object sender, EventArgs e)
        {
            ucMain.Size = this.Size;
            ucMain.Refresh();
        }
    }
}
