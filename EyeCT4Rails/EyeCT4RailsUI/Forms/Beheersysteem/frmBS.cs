using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EyeCT4RailsUI.Forms.Beheersysteem.UserControls;
using EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls;

namespace EyeCT4RailsUI.Forms.Beheersysteem
{
    public partial class frmBs : Form
    {
        private Dictionary<ToolStripMenuItem, string> _namespaces;

        public frmBs()
        {
            InitializeComponent();

            _namespaces = new Dictionary<ToolStripMenuItem, string>();
            _namespaces.Add(tramsToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(sporenToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(schoonmaakToolStripMenuItem, typeof(ucSchoonmaak).Namespace);
        }

        private void UserControl_Change(object sender, EventArgs e)
        {
            try
            {
                string ns = "";

                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item.OwnerItem == null)
                {
                    ns = _namespaces[item as ToolStripMenuItem];
                }
                else
                {
                    ns = _namespaces[item.OwnerItem as ToolStripMenuItem];
                }
                
                string strNamespace = ns + GetUcName(item.Text);

                Type type = Type.GetType(strNamespace);
                var uc = (UserControl) Activator.CreateInstance(type);

                panelControls.Controls.Clear();
                panelControls.Controls.Add(uc);
                panelControls.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Menuitem not found!");
            }
        }

        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static string GetUcName(string text)
        {
            List<string> names = new List<string>();

            string fullName = "";
            string itemNaam = text;
            int index = itemNaam.IndexOf(" ");

            if (index > 0)
            {
                do
                {
                    names.Add(UppercaseFirst(itemNaam.Substring(0, index)));
                    itemNaam = itemNaam.Substring(index + 1, itemNaam.Length - 1 - index);
                    index = itemNaam.IndexOf(" ");
                } while (index > 0);
            }

            names.Add(UppercaseFirst(itemNaam));

            fullName += ".uc";

            fullName = names.Aggregate(fullName, (current, name) => current + name);

            return fullName;
        }
    }
}
