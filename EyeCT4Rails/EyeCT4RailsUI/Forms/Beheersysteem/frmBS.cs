using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsUI.Forms.Beheersysteem.UserControls;
using EyeCT4RailsUI.Forms.InUitSysteem;
using EyeCT4RailsUI.Forms.Login;
using EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls;
using EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls;

namespace EyeCT4RailsUI.Forms.Beheersysteem
{
    public partial class frmBS : Form
    {
        private readonly Dictionary<ToolStripMenuItem, string> _namespaces;

        private ucLogIn _ucLogIn;

        private User _currentUser;

        public frmBS()
        {
            InitializeComponent();

            _namespaces = new Dictionary<ToolStripMenuItem, string>();
            _ucLogIn = new ucLogIn();

            _namespaces.Add(tramsToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(sporenToolStripMenuItem, typeof(ucTramPlaatsen).Namespace);
            _namespaces.Add(schoonmaakToolStripMenuItem, typeof(ucSchoonmaak).Namespace);
            _namespaces.Add(reparatieToolStripMenuItem, typeof(ucReparatie).Namespace);
            _namespaces.Add(overzichtBSToolStripMenuItem, typeof(ucOverzichtBS).Namespace);
            _namespaces.Add(inEnUitrijSysteemToolStripMenuItem, typeof(ucInEnUitRijSysteem).Namespace);

            msMenu.Visible = false;
            AddControl(_ucLogIn);
            _ucLogIn.LoginSucceeded += LoginSucceeded;

            foreach (ToolStripMenuItem item in msMenu.Items)
            {
                item.Enabled = false;
            }
        }

        private void LoginSucceeded(object sender, EventArgs e)
        {
            _ucLogIn.Dispose();
            _currentUser = sender as User;
            msMenu.Visible = true;

            ShowMenuItems(_currentUser.Privilege);

            UpdateTitle("");
        }

        private void ShowMenuItems(Privilege privilege)
        {
            switch (_currentUser.Privilege)
            {
                case Privilege.Administrator:
                    foreach (ToolStripMenuItem item in msMenu.Items)
                    {
                        item.Enabled = true;
                    }

                    break;
                case Privilege.Mechanic:
                    reparatieToolStripMenuItem.Enabled = true;

                    break;
                case Privilege.Cleanup:
                    schoonmaakToolStripMenuItem.Enabled = true;

                    break;
                case Privilege.DepotMananger:
                    overzichtBSToolStripMenuItem.Enabled = true;
                    tramsToolStripMenuItem.Enabled = true;
                    sporenToolStripMenuItem.Enabled = true;

                    break;
                case Privilege.Driver:
                    inEnUitrijSysteemToolStripMenuItem.Enabled = true;

                    break;
            }

            exitToolStripMenuItem.Enabled = true;
        }

        private void UserControl_Change(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;

                AddControl(GetUserControl(sender));

                UpdateTitle(item.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Menu item not found!");
            }
        }

        private void UpdateTitle(string titleExtension)
        {
            this.Text = _currentUser.Privilege + " - " + titleExtension;
        }

        private void AddControl(UserControl uc)
        {
            panelControls.Controls.Clear();
            panelControls.Controls.Add(uc);

            uc.Size = panelControls.Size;
            uc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            panelControls.Refresh();
        }

        private UserControl GetUserControl(object sender)
        {
            string ns = "";

            ToolStripMenuItem item = sender as ToolStripMenuItem;

            ns = item.OwnerItem == null ? _namespaces[item as ToolStripMenuItem] : _namespaces[item.OwnerItem as ToolStripMenuItem];

            string strNamespace = ns + GetUcName(item.Text);

            Type type = Type.GetType(strNamespace);

            var uc = (UserControl) Activator.CreateInstance(type);

            if (type == typeof(ucSchoonmaak))
            {
                (uc as ucSchoonmaak).Cel_DoubleClicked += CelDoubleClicked;
            }
            else if (type == typeof(ucReparatie))
            {
                (uc as ucReparatie).Cel_DoubleClicked += CelDoubleClicked;
            }

            return uc;
        }

        public void CelDoubleClicked(object sender, EventArgs e)
        {
            DataGridView data = sender as DataGridView;

            if (data != null)
            {
                if (data.SelectedCells[0].ColumnIndex == 1)
                {
                    string tramNummer = data.SelectedCells[0].EditedFormattedValue.ToString();

                    ucTramHistorieSCH uc = new ucTramHistorieSCH(tramNummer);

                    AddControl(uc);

                    UpdateTitle("Historie");
                }
            }
        }

        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private string GetUcName(string text)
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
