using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Windows.Forms;
using EyeCT4RailsUI.Forms.Beheersysteem.UserControls;
using EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls;
using EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls;

namespace EyeCT4RailsUI.Forms.Beheersysteem
{
    public partial class frmBS : Form
    {
        private readonly Dictionary<ToolStripMenuItem, string> _namespaces;

        public frmBS()
        {
            InitializeComponent();

            _namespaces = new Dictionary<ToolStripMenuItem, string>();

            _namespaces.Add(tramsToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(sporenToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(schoonmaakToolStripMenuItem, typeof(ucSchoonmaak).Namespace);
            _namespaces.Add(reparatieToolStripMenuItem, typeof(ucReparatie).Namespace);
            _namespaces.Add(overzichtBSToolStripMenuItem, typeof(ucOverzichtBS).Namespace);
        }

        private void UserControl_Change(object sender, EventArgs e)
        {
            try
            {
                string ns = "";

                ToolStripMenuItem item = sender as ToolStripMenuItem;

                ns = item.OwnerItem == null ? _namespaces[item as ToolStripMenuItem] : _namespaces[item.OwnerItem as ToolStripMenuItem];
                
                string strNamespace = ns + GetUcName(item.Text);

                Type type = Type.GetType(strNamespace);
                var uc = (UserControl) Activator.CreateInstance(type);

                panelControls.Controls.Clear();
                panelControls.Controls.Add(uc);

                uc.Size = panelControls.Size;
                uc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                this.Text = "Beheersysteem - " + item.Text;

                panelControls.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Menu item not found!");
            }
        }

        public void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
        {
            DataGridView data = sender as DataGridView;

            string tramNumer =
                data.Rows[data.SelectedRows[0].Index].Cells[data.SelectedColumns[0].Index].EditedFormattedValue.ToString
                    ();
        }

        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private static string GetUcName(string text)
        {
            List<string> names = new List<string>();

            string fullName = "";
            string itemNaam = text;
            int index = itemNaam.IndexOf(" ", StringComparison.Ordinal);

            while (index > 0)
            {
                names.Add(UppercaseFirst(itemNaam.Substring(0, index)));
                itemNaam = itemNaam.Substring(index + 1, itemNaam.Length - 1 - index);
                index = itemNaam.IndexOf(" ", StringComparison.Ordinal);
            }

            names.Add(UppercaseFirst(itemNaam));

            fullName += ".uc";
            fullName = names.Aggregate(fullName, (current, name) => current + name);

            return fullName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
