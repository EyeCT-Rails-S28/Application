﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcOverzichtBs : UserControl
    {
        private const int SECTION_WIDTH = 45;
        private const int SECTION_HEIGHT = 45;
        private const int LEFT_MARGIN = 5;
        private const int ABOVE_MARGIN = 5;
        private const int NEWLINE_MARGIN = 20;

        public event EventHandler SelectionChanged;
        public event EventHandler SpoorInfo;

        private Depot _depot;
        private readonly List<TrackUiObj> _tracks;
        private Track _selectedTrack;
        private Section _selectedSection;
        private List<Tram> _needyTrams;

        public UcOverzichtBs()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlTracks, new object[] { true });
            
            _tracks = new List<TrackUiObj>();
            _needyTrams = new List<Tram>();

            RefreshControl();
        }

        private void RefreshControl()
        {
            RefreshDepot();
            CheckForReservedFlag();
            RefreshUi();
        }

        private void RefreshDepot()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                _depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Console.Write($"It took {watch.ElapsedMilliseconds} ms to load from the database ");
                _tracks.Clear();

                if (_depot != null)
                {
                    foreach (var track in _depot.Tracks)
                    {
                        TrackUiObj trackUiObj = new TrackUiObj(track.Id);
                        foreach (var section in track.Sections)
                        {
                            trackUiObj.AddSection(section);
                        }

                        trackUiObj.ConvertSections();
                        _tracks.Add(trackUiObj);
                    }
                }

                pnlTracks.Refresh();
                Console.WriteLine($"and a total of {watch.ElapsedMilliseconds} ms to refresh the depot.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Fout bij herladen van de Depot: {ex.Message}");
            }
        }

        private void DrawSections(Graphics g)
        {
            int x = LEFT_MARGIN;
            int y = ABOVE_MARGIN;
            int maxHeight = 0;

            foreach (TrackUiObj track in _tracks)
            {
                track.DrawSections(g, x, y, _selectedSection?.Id ?? -1);

                if (maxHeight < track.Height)
                {
                    maxHeight = track.Height;
                }

                x += SECTION_WIDTH;

                int newLine = x + SECTION_WIDTH + NEWLINE_MARGIN;
                if (newLine > pnlTracks.Width)
                {
                    x = LEFT_MARGIN;
                    y += maxHeight + NEWLINE_MARGIN;
                    maxHeight = 0;
                }
            }
        }

        private void pnlTracks_Paint(object sender, PaintEventArgs e)
        {
            DrawSections(e.Graphics);
        }

        private void pnlTracks_MouseClick(object sender, MouseEventArgs e)
        {
            SelectSection(e.Location);
        }

        private void SelectSection(Point p)
        {
            try
            {
                var track = _tracks.Find(x => x.Area.Contains(p));
                var section = track.UiSections.Find(x => x.Area.Contains(p));

                _selectedTrack = track;
                _selectedSection = section;
                btnBevestig.Enabled = lbReserveringen.SelectedItem != null && _selectedSection != null;

                SelectionChanged?.Invoke(_selectedTrack, new EventArgs());

                if (section != null)
                    SelectionChanged?.Invoke(_selectedSection, new EventArgs());

                RefreshUi();
                Refresh();
            }
            catch(NullReferenceException ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        private void RefreshUi()
        {
            lblSeletedTrack.Text = _selectedTrack == null 
                ? "Selected track:" 
                : $"Selected track: {_selectedTrack.Id}";
            lblSelectedSection.Text = _selectedSection == null
                ? "Selected section:"
                : $"Selected section: {_selectedSection.Id}";

            int index = lbReserveringen.SelectedIndex;
            lbReserveringen.Items.Clear();

            foreach (var tram in _needyTrams)
            {
                lbReserveringen.Items.Add(tram);
            }

            if (index > -1 && lbReserveringen.Items.Count > index) 
                lbReserveringen.SelectedIndex = index;
        }

        private void ucOverzichtBS_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshControl();
        }

        private void CheckForReservedFlag()
        {
            try
            {
                List<Tram> trams = DepotManagementRepository.Instance.GetTramsWithReservedFlag();

                if (trams.Exists(x => !_needyTrams.Exists(y => x.Id == y.Id)))
                {
                    timer.Enabled = false;
                    MessageBox.Show("Er is een tram die een handmatige invoer vereist.");
                    timer.Enabled = true;

                    RefreshDepot();
                }

                _needyTrams.Clear();
                _needyTrams.AddRange(trams);

                RefreshUi();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Er is een fout opgetreden bij het ophalen van de gegevens: {ex.Message}");
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            if (sender == tramPlaatsenToolStripMenuItem || sender == reserveringPlaatsenToolStripMenuItem)
            {
                if (_selectedSection == null)
                {
                    return;
                }

                if (_selectedSection.Tram != null)
                {
                    MessageBox.Show("Deze sectie bevat al een tram!");
                    return;
                }

                if (!(RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, false) ||
                    RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, true)))
                {
                    MessageBox.Show("Op deze sectie kan geen tram geplaatst worden!");
                    return;
                }

                string input = Prompt.ShowDialog("Welke tram wilt u plaatsen?", "Tram plaatsen");
                if (string.IsNullOrWhiteSpace(input))
                {
                    return;
                }

                try
                {
                    int tramId = Convert.ToInt32(input);
                    if (_depot.Tracks.Any(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null))
                    {
                        MessageBox.Show($"De tram met nummer {tramId} is al geplaatst.");
                        return;
                    }

                    DepotManagementRepository.Instance.ReserveSection(tramId, _selectedSection.Id);

                    Tram tram = _depot.Trams.Find(t => t.Id == tramId);
                    if (tram.Status != Status.Defect && tram.Status != Status.Schoonmaak)
                    {
                        DepotManagementRepository.Instance.ChangeTramStatus(tramId, sender == reserveringPlaatsenToolStripMenuItem ? Status.Dienst : Status.Remise);
                    }

                    RefreshDepot();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show($"Fout bij tram plaatsen: {ex.Message}");
                }
            }
            else if (sender == tramVerwijderenToolStripMenuItem)
            {
                if (_selectedSection != null && _selectedSection.Tram != null)
                {
                    try
                    {
                        if (!(RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection.NextSection, true) ||
                              RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection.PreviousSection, false)))
                        {
                            MessageBox.Show("Deze tram kan niet verwijderd worden.");
                            return;
                        }

                        DepotManagementRepository.Instance.RemoveTram(_selectedSection.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show($"Fout bij tram verwijderen: {ex.Message}");
                    }
                    RefreshDepot();
                }
            }
            else if (sender == defectToolStripMenuItem || sender == remiseToolStripMenuItem ||
                     sender == dienstToolStripMenuItem || sender == schoonmaakToolStripMenuItem)
            {
                if (_selectedSection != null && _selectedSection.Tram != null)
                {
                    Status status = (Status)Enum.Parse(typeof(Status), (sender as ToolStripMenuItem).Text);

                    try
                    {
                        DepotManagementRepository.Instance.ChangeTramStatus(_selectedSection.Tram.Id, status);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show($"Fout bij veranderen van status: {ex.Message}");
                    }

                    RefreshDepot();
                }
            }
            else if (sender == toggleBlokkadeToolStripMenuItem)
            {
                if (_selectedSection != null || _selectedTrack != null)
                {
                    try
                    {
                        if (_selectedTrack != null && _selectedSection == null)
                        {
                            bool allFree = _depot.Tracks.Find(t => t.Id == _selectedTrack.Id)
                                                 .Sections.TrueForAll(s => s.Tram == null);
                            if (!allFree)
                            {
                                MessageBox.Show("Een of meerdere secties binnen deze track kunnen niet geblokkeerd worden.");
                                return;
                            }

                            bool allBlocked = _depot.Tracks.Find(t => t.Id == _selectedTrack.Id).Sections.TrueForAll(s => s.Blocked);
                            DepotManagementRepository.Instance.SetTrackBlocked(_selectedTrack.Id, !allBlocked);
                        }
                        else if (_selectedSection != null && _selectedTrack != null)
                        {
                            if (!(RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, false) ||
                                  RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, true)) && _selectedSection.Tram != null)
                            {
                                MessageBox.Show("Deze sectie kan niet geblokkeerd worden!");
                                return;
                            }
                            DepotManagementRepository.Instance.SetSectionBlocked(_selectedSection.Id, !_selectedSection.Blocked);
                        }

                        RefreshDepot();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show($"Fout bij blokkade: {ex.Message}");
                    }
                }
            } else if (sender == spoorInformatieToolStripMenuItem)
            {
                if (_selectedTrack != null)
                {
                    SpoorInfo?.Invoke(_selectedTrack, new EventArgs());
                }
            }
        }

        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            Point p = pnlTracks.PointToClient(Cursor.Position);
            SelectSection(p);
        }

        private class TrackUiObj : Track
        {
            public List<SectionUiObj> UiSections => new List<SectionUiObj>(_uiSections);

            public int Height { get; private set; }

            public Rectangle Area { get; private set; }

            private readonly List<SectionUiObj> _uiSections;

            public TrackUiObj(int id) : base(id)
            {
                _uiSections = new List<SectionUiObj>();
            }

            public void ConvertSections()
            {
                foreach (var section in Sections)
                {
                    SectionUiObj sectionUiObj = section.Tram == null
                        ? new SectionUiObj(section.Id, section.Blocked)
                        : new SectionUiObj(section.Id, section.Blocked, section.Tram);
                    sectionUiObj.AddNextSection(section.NextSection);
                    sectionUiObj.AddPreviousSection(section.PreviousSection);
                    
                    _uiSections.Add(sectionUiObj);
                }

                Height = (Sections.Count + 1) * SECTION_HEIGHT;
            }

            public void DrawSections(Graphics g, int x, int y, int selectedSectionId)
            {
                Font font = new Font(FontFamily.GenericSansSerif, 11);

                Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT * (UiSections.Count + 1));

                g.DrawRectangle(Pens.Black, x, y, SECTION_WIDTH, SECTION_HEIGHT);
                g.DrawString(Convert.ToString(Id), font, Brushes.Black, x, y);
                y += SECTION_HEIGHT;

                for (int i = 0; i < UiSections.Count; i++)
                {
                    _uiSections[i].Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT);

                    g.DrawRectangle(Pens.Black, _uiSections[i].Area);
                    if (_uiSections[i].Id == selectedSectionId)
                    {
                        g.FillRectangle(Brushes.LightBlue, x + 1, y + 1, SECTION_WIDTH - 1, SECTION_HEIGHT - 1);
                    }

                    if (_uiSections[i].Blocked)
                    {
                        g.FillRectangle(Brushes.DimGray, x + 1, y + 1, SECTION_WIDTH - 1, SECTION_HEIGHT - 1);

                        g.DrawLine(Pens.Red, x, y, x + SECTION_WIDTH, y + SECTION_HEIGHT);
                        g.DrawLine(Pens.Red, x + SECTION_WIDTH, y, x, y + SECTION_HEIGHT);
                    }
                    else if (_uiSections[i].Tram != null)
                    {
                        Brush brush = Brushes.Black;
                        switch (_uiSections[i].Tram.Status)
                        {
                            case Status.Defect:
                                brush = Brushes.Red;
                                break;
                            case Status.Remise:
                                brush = Brushes.Black;
                                break;
                            case Status.Dienst:
                                brush = Brushes.Purple;
                                break;
                            case Status.Schoonmaak:
                                brush = Brushes.Blue;
                                break;
                            case Status.Gereserveerd:
                                brush = Brushes.DarkOrange;
                                break;
                        }

                        g.DrawString(Convert.ToString(_uiSections[i].Tram.Id), font, brush,  x + 5, y + (SECTION_HEIGHT / 2));
                    }

                    y += SECTION_HEIGHT;
                }
            }
        }

        private class SectionUiObj : Section
        {
            public Rectangle Area { get; set; }

            public SectionUiObj(int id, bool blocked) : base(id, blocked)
            {

            }

            public SectionUiObj(int id, bool blocked, Tram tram) : base(id, blocked, tram)
            {
                
            }
        }

        private void btnBevestig_Click(object sender, EventArgs e)
        {
            if (_selectedSection == null)
            {
                return;
            }

            if (!RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, true) &&
                !RideManagementRepository.Instance.CheckSectionFreedom(_selectedSection, false))
            {
                MessageBox.Show("Het is niet mogelijk om de geselecteerde tram op de geselecteerde sectie te plaatsen.");
                return;
            }

            try
            {
                Tram tram = (Tram) lbReserveringen.SelectedItem;

                DepotManagementRepository.Instance.ReserveSection(tram.Id, _selectedSection.Id);
                DepotManagementRepository.Instance.ChangeTramStatus(tram.Id, Status.Defect);

                RefreshDepot();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void lbReserveringen_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBevestig.Enabled = lbReserveringen.SelectedItem != null && _selectedSection != null;
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            RefreshDepot();

            List<Section> sections = new List<Section>();
            _depot.Tracks.ForEach(t => sections.AddRange(t.Sections));

            List<Tram> parkedTrams = new List<Tram>();
            sections.FindAll(s => s.Tram != null).ForEach(s => parkedTrams.Add(s.Tram));

            List<Tram> unparkedTrams = new List<Tram>(_depot.Trams);
            unparkedTrams.RemoveAll(t => parkedTrams.Contains(t));

            int count = unparkedTrams.Count;
            Random random = new Random();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    Tram tram = unparkedTrams[random.Next(unparkedTrams.Count)];
                    Section section = RideManagementRepository.Instance.GetFreeSection(_depot, tram.TramType);

                    DepotManagementRepository.Instance.ReserveSection(tram.Id, section.Id);

                    unparkedTrams.Remove(tram);

                    RefreshControl();
                    Thread.Sleep(500);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
