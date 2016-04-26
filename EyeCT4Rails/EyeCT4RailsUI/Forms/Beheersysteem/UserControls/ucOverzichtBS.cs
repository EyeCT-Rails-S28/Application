using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcOverzichtBs : UserControl
    {
        private const int SECTION_WIDTH = 50;
        private const int SECTION_HEIGHT = 50;
        private const int LEFT_MARGIN = 5;
        private const int ABOVE_MARGIN = 5;
        private const int NEWLINE_MARGIN = 20;

        public event EventHandler SelectionChanged;

        private Depot _depot;
        private readonly List<TrackUiObj> _tracks;
        private Track _selectedTrack;
        private Section _selectedSection;

        public UcOverzichtBs()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlTracks, new object[] { true });
            
            _tracks = new List<TrackUiObj>();
        }

        public void SetDepot(Depot depot)
        {
            _depot = depot;

            if (depot != null)
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
        }

        private void DrawSections(Graphics g)
        {
            int x = LEFT_MARGIN;
            int y = ABOVE_MARGIN;
            int maxHeight = 0;

            foreach (TrackUiObj track in _tracks)
            {
                track.DrawSections(g, x, y);

                if (maxHeight < track.Height)
                {
                    maxHeight = track.Height;
                }

                x += SECTION_WIDTH;

                if (x + SECTION_WIDTH + NEWLINE_MARGIN > pnlTracks.Width)
                {
                    x = LEFT_MARGIN;
                    y += maxHeight + NEWLINE_MARGIN;
                    maxHeight = 0;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawSections(e.Graphics);
        }

        private void pnlTracks_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var track = _tracks.Find(x => x.Area.Contains(e.Location));
                var section = track.UiSections.Find(x => x.Area.Contains(e.Location));
                
                _selectedTrack = track;
                _selectedSection = section;

                SelectionChanged?.Invoke(_selectedTrack, e);

                if (section != null) SelectionChanged?.Invoke(_selectedSection, e);
                
                RefreshUi();
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
        }

        private void ucOverzichtBS_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private class TrackUiObj : Track
        {
            public List<SectionUiObj> UiSections => new List<SectionUiObj>(_uiSections);

            public int Height { get; }

            public Rectangle Area { get; private set; }

            private readonly List<SectionUiObj> _uiSections;

            public TrackUiObj(int id) : base(id)
            {
                _uiSections = new List<SectionUiObj>();

                Height = (Sections.Count + 1)*SECTION_HEIGHT;
            }

            public void ConvertSections()
            {
                foreach (var section in Sections)
                {
                    _uiSections.Add(section.Tram == null
                        ? new SectionUiObj(section.Id, section.Blocked)
                        : new SectionUiObj(section.Id, section.Blocked, section.Tram));
                }
            }

            public void DrawSections(Graphics g, int x, int y)
            {
                Font font = new Font(FontFamily.GenericSansSerif, 12);

                Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT * (UiSections.Count + 1));

                g.DrawRectangle(Pens.Black, x, y, SECTION_WIDTH, SECTION_HEIGHT);
                g.DrawString(Convert.ToString(Id), font, Brushes.Black, x, y);
                y += SECTION_HEIGHT;

                for (int i = 0; i < UiSections.Count; i++)
                {
                    _uiSections[i].Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT);

                    g.DrawRectangle(Pens.Black, _uiSections[i].Area);

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
                            case Status.Dienst:
                                brush = Brushes.Black;
                                break;
                            case Status.Schoonmaak:
                                brush = Brushes.Blue;
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
    }
}
