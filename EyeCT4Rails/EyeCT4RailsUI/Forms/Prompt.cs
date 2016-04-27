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
            Dispose();
        }

        public static string ShowDialog(string text, string caption)
        {
            Prompt prompt = new Prompt();
            prompt.Text = text;
            prompt.lblText.Text = text + ": ";

            prompt.ShowDialog();

            return prompt.txtBox.Text;
        }
    }
}
