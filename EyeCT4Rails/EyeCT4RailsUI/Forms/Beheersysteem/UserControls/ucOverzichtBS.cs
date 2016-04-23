using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

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
        private List<TrackUiObj> _tracks;
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
                    _tracks.Add(new TrackUiObj(track.Id));
                }
            }
            else
            {
                //make test tracks
                Random r = new Random();

                for (int i = 0; i < 40; i++)
                {
                    _tracks.Add(new TrackUiObj(i, r.Next(1, 5)));
                }
            }
        }

        private void DrawSections(Graphics g)
        {
            int x = LEFT_MARGIN;
            int y = ABOVE_MARGIN;
            int maxHeight = 0;

            Size ucSize = this.Size;

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

                SelectionChanged?.Invoke(_selectedTrack, e);

                if (section != null)
                {
                    _selectedSection = section;

                    SelectionChanged?.Invoke(_selectedSection, e);
                }
                
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

            private List<SectionUiObj> _uiSections;

            //test constructor
            public TrackUiObj(int id, int amountOfSections) : base(id)
            {
                //make test sections
                _uiSections = new List<SectionUiObj>();

                for (int i = 0; i < amountOfSections; i++)
                {
                    AddSection(new Section(i, true));
                }

                ConvertSections();

                Height = (UiSections.Count + 1) * SECTION_HEIGHT;
            }

            public TrackUiObj(int id) : base(id)
            {
                ConvertSections();

                Height = (UiSections.Count + 1)*SECTION_HEIGHT;
            }

            private void ConvertSections()
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
                Pen pen = new Pen(Color.Black, 1);
                Brush brush = new SolidBrush(Color.Black);
                Font font = new Font(FontFamily.GenericSansSerif, 12);

                Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT * (UiSections.Count + 1));

                g.DrawRectangle(pen, x, y, SECTION_WIDTH, SECTION_HEIGHT);
                g.DrawString(Convert.ToString(Id), font, brush, x, y);
                y += SECTION_HEIGHT;

                for (int i = 0; i < UiSections.Count; i++)
                {
                    _uiSections[i].Area = new Rectangle(x, y, SECTION_WIDTH, SECTION_HEIGHT);

                    g.DrawRectangle(pen, _uiSections[i].Area);

                    y += SECTION_HEIGHT;
                }
            }
        }

        class SectionUiObj : Section
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
