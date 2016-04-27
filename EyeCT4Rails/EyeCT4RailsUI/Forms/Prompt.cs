using System;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms
{
    public partial class Prompt : Form
    {
        private Prompt()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public static string ShowDialog(string text, string caption)
        {
            Prompt prompt = new Prompt();
            prompt.Text = caption;
            prompt.lblText.Text = text + ": ";
            prompt.AcceptButton = prompt.btnSubmit;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return prompt.txtBox.Text;
            }

            return null;
        }
    }
}
