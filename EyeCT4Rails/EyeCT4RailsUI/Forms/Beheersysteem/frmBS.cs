using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;
using EyeCT4RailsUI.Forms.Beheersysteem.UserControls;
using EyeCT4RailsUI.Forms.InUitSysteem;
using EyeCT4RailsUI.Forms.Login;
using EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls;
using EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls;

namespace EyeCT4RailsUI.Forms.Beheersysteem
{
    public partial class FrmBs : Form
    {
        private readonly Dictionary<ToolStripMenuItem, string> _namespaces;

        private readonly UcLogIn _ucLogIn;
        private User _currentUser;
        private Track _selectedTrack;
        private Section _selectedSection;

        public FrmBs()
        {
            InitializeComponent();

            _namespaces = new Dictionary<ToolStripMenuItem, string>();
            _ucLogIn = new UcLogIn();

            _namespaces.Add(tramsToolStripMenuItem, typeof(UcTramInfo).Namespace);
            _namespaces.Add(schoonmaakToolStripMenuItem, typeof(UcSchoonmaak).Namespace);
            _namespaces.Add(reparatieToolStripMenuItem, typeof(UcReparatie).Namespace);
            _namespaces.Add(overzichtBSToolStripMenuItem, typeof(UcOverzichtBs).Namespace);
            _namespaces.Add(inEnUitrijSysteemToolStripMenuItem, typeof(UcInEnUitRijSysteem).Namespace);
            _namespaces.Add(gebruikerBeheerToolStripMenuItem, typeof(UcMaakGebruiker).Namespace);

            msMenu.Visible = false;
            AddControl(_ucLogIn);
            _ucLogIn.LoginSucceeded += LoginSucceeded;

            foreach (ToolStripMenuItem item in msMenu.Items)
            {
                item.Visible = false;
            }
        }

        private void LoginSucceeded(object sender, EventArgs e)
        {
            _ucLogIn.Dispose();
            _currentUser = sender as User;
            msMenu.Visible = true;

            ShowMenuItems();
            SetDefaultControl();

            UpdateTitle("");
        }

        private void ShowMenuItems()
        {
            switch (_currentUser.Role)
            {
                case Role.Administrator:
                    foreach (ToolStripMenuItem item in msMenu.Items)
                    {
                        item.Visible = true;
                    }
                    break;
                case Role.Mechanic:
                    reparatieToolStripMenuItem.Visible = true;

                    break;
                case Role.Cleanup:
                    schoonmaakToolStripMenuItem.Visible = true;

                    break;
                case Role.DepotManager:
                    overzichtBSToolStripMenuItem.Visible = true;
                    tramsToolStripMenuItem.Visible = true;

                    break;
                case Role.Driver:
                    inEnUitrijSysteemToolStripMenuItem.Visible = true;

                    break;
            }

            exitToolStripMenuItem.Visible = true;
        }

        private void SetDefaultControl()
        {
            switch (_currentUser.Role)
            {
                case Role.DepotManager:
                case Role.Administrator:
                    UserControl_Change(overzichtBSToolStripMenuItem, new EventArgs());
                    break;
                case Role.Mechanic:
                    UserControl_Change(reparatieToolStripMenuItem, new EventArgs());
                    break;
                case Role.Cleanup:
                    UserControl_Change(schoonmaakToolStripMenuItem, new EventArgs());
                    break;
                case Role.Driver:
                    UserControl_Change(inEnUitrijSysteemToolStripMenuItem, new EventArgs());
                    break;
            }
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
            Text = _currentUser.Role + " - " + titleExtension;
        }

        private void AddControl(Control uc)
        {
            if (panelControls.Controls.Count > 0)
                panelControls.Controls[0].Dispose();
            panelControls.Controls.Clear();
            panelControls.Controls.Add(uc);

            uc.Size = panelControls.Size;
            uc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            panelControls.Refresh();
        }

        private UserControl GetUserControl(object sender)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string ns = item.OwnerItem == null ? _namespaces[item] : _namespaces[item.OwnerItem as ToolStripMenuItem];
            string strNamespace = ns + GetUcName(item.Text);

            Type type = Type.GetType(strNamespace);

            var uc = (UserControl) Activator.CreateInstance(type);
            SetUcSpecificChanges(type, uc);
            return uc;
        }

        private void SetUcSpecificChanges(Type type, UserControl uc)
        {
            if (type == typeof(UcSchoonmaak))
            {
                (uc as UcSchoonmaak).CelDoubleClicked += CelDoubleClickedCleanUp;
            }
            else if (type == typeof(UcReparatie))
            {
                (uc as UcReparatie).CelDoubleClicked += CelDoubleClickedMaintenance;
            }
            else if (type == typeof(UcOverzichtBs))
            {
                (uc as UcOverzichtBs).SelectionChanged += SelectionChanged;
                (uc as UcOverzichtBs).SpoorInfo += SpoorInfo;
            }
            else if (type == typeof(UcSpoorInfo))
            {
                (uc as UcSpoorInfo).SetSelection(_selectedTrack);
            }
            else if (type == typeof(UcPlanSchoonmaak))
            {
                (uc as UcPlanSchoonmaak).SetUser(_currentUser);
            }
            else if (type == typeof(UcPlanReparatie))
            {
                (uc as UcPlanReparatie).SetUser(_currentUser);
            }
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as Track) != null)
            {
                _selectedTrack = (Track) sender;
                _selectedSection = null;
            }

            if ((sender as Section) != null)
            {
                _selectedSection = (Section) sender;
            }
        }

        private void SpoorInfo(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            Track track = sender as Track;
            UcSpoorInfo info = Activator.CreateInstance(typeof (UcSpoorInfo)) as UcSpoorInfo;
            info.SetSelection(track);
            AddControl(info);
        }

        public void CelDoubleClickedCleanUp(object sender, EventArgs e)
        {
            DataGridView data = sender as DataGridView;
            if (data == null)
            {
                return;
            }

            DataGridViewRow selected = data.SelectedRows[0];
            if (selected == null)
            {
                return;
            }

            int tramId = Convert.ToInt32(selected.Cells[2].Value);
            UcTramHistorieSch uc = new UcTramHistorieSch(tramId);
            AddControl(uc);
            UpdateTitle("Historie");
        }

        public void CelDoubleClickedMaintenance(object sender, EventArgs e)
        {
            DataGridView data = sender as DataGridView;
            if (data == null)
            {
                return;
            }

            DataGridViewRow selected = data.SelectedRows[0];
            if (selected == null)
            {
                return;
            }

            int tramId = Convert.ToInt32(selected.Cells[2].Value);
            UcTramHistorieRs uc = new UcTramHistorieRs(tramId);
            AddControl(uc);
            UpdateTitle("Historie");
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

            fullName += ".Uc";
            fullName = names.Aggregate(fullName, (current, name) => current + name);

            return fullName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zoekSchoonmaakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int tramId = Convert.ToInt32(Prompt.ShowDialog("Voor welk tramnummer wilt u de historie opzoeken?", "Zoek schoonmaak historie"));

                UcTramHistorieSch uc = new UcTramHistorieSch(tramId);
                AddControl(uc);
                UpdateTitle("Historie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void zoekReparatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int tramId = Convert.ToInt32(Prompt.ShowDialog("Voor welk tramnummer wilt u de historie opzoeken?", "Zoek reparatie historie"));

                UcTramHistorieRs uc = new UcTramHistorieRs(tramId);
                AddControl(uc);
                UpdateTitle("Historie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void historieSchoonmaakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UcTramHistorieSch uc = new UcTramHistorieSch();
                AddControl(uc);
                UpdateTitle("Historie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void historieReparatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UcTramHistorieRs uc = new UcTramHistorieRs();
                AddControl(uc);
                UpdateTitle("Historie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
