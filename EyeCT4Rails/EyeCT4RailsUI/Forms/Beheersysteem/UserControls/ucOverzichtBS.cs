using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class ucOverzichtBS : UserControl
    {
        private const int SectionWidth = 50;
        private const int SectionHeight = 50;
        private const int LeftMargin = 5;
        private const int AboveMargin = 5;
        private const int NewlineMargin = 20;
        
        private List<TrackUIObj> _tracks;

        public ucOverzichtBS()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlTracks, new object[] { true });

            Random r = new Random();
            _tracks = new List<TrackUIObj>();

            //make test tracks
            for (int i = 0; i < 40; i++)
            {
                _tracks.Add(new TrackUIObj(i,r.Next(1,5)));
            }
        }
        

        private void DrawSections(Graphics g)
        {
            int x = LeftMargin;
            int y = AboveMargin;
            int maxHeight = 0;

            Size ucSize = this.Size;

            foreach (TrackUIObj track in _tracks)
            {
                track.DrawSections(g, x, y);

                if (maxHeight < track.Height)
                {
                    maxHeight = track.Height;
                }

                x += SectionWidth;

                if (x + SectionWidth + NewlineMargin > pnlTracks.Width)
                {
                    x = LeftMargin;
                    y += maxHeight + NewlineMargin;
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

                string message = (section == null ? $"Clicked: {track.Id}" :
                $"Clicked: {track.Id}; Section: {section.Id}");

                MessageBox.Show(message);
            }
            catch(NullReferenceException ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        private void ucOverzichtBS_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private class TrackUIObj : Track
        {
            public List<SectionUIObj> UiSections => new List<SectionUIObj>(_uiSections);

            public int Height { get; }

            public Rectangle Area { get; private set; }

            public Section SelectedSection { get; private set; }

            private List<SectionUIObj> _uiSections;

            public TrackUIObj(int id, int amountOfSections) : base(id)
            {
                //make test sections
                _uiSections = new List<SectionUIObj>();  

                for (int i = 0; i < amountOfSections; i++)
                {
                    AddSection(new Section(i, true));
                }

                foreach (var section in Sections)
                {
                    _uiSections.Add(section.Tram == null
                        ? new SectionUIObj(section.Id, section.Blocked)
                        : new SectionUIObj(section.Id, section.Blocked, section.Tram));
                }

                Height = (UiSections.Count + 1)*SectionHeight;
            }

            public void DrawSections(Graphics g, int x, int y)
            {
                Pen pen = new Pen(Color.Black, 1);
                Brush brush = new SolidBrush(Color.Black);
                Font font = new Font(FontFamily.GenericSansSerif, 12);

                Area = new Rectangle(x, y, SectionWidth, SectionHeight * (UiSections.Count + 1));

                g.DrawRectangle(pen, x, y, SectionWidth, SectionHeight);
                g.DrawString(Convert.ToString(Id), font, brush, x, y);
                y += SectionHeight;

                for (int i = 0; i < UiSections.Count; i++)
                {
                    _uiSections[i].Area = new Rectangle(x, y, SectionWidth, SectionHeight);

                    g.DrawRectangle(pen, _uiSections[i].Area);

                    y += SectionHeight;
                }
            }

            public bool OnArea(Point point)
            {
                SelectedSection = _uiSections.Find(x => x.Area.Contains(point));

                return SelectedSection != null;
            }
        }

        class SectionUIObj : Section
        {
            public Rectangle Area { get; set; }

            public SectionUIObj(int id, bool blocked) : base(id, blocked)
            {

            }

            public SectionUIObj(int id, bool blocked, Tram tram) : base(id, blocked, tram)
            {
                
            }
        }
    }
}
