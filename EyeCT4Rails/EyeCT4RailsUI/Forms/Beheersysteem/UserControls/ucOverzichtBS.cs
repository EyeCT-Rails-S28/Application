using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcOverzichtBs : UserControl
    {
        private const int SECTION_WIDTH = 50;
        private const int SECTION_HEIGHT = 50;
        private const int LEFT_MARGIN = 5;
        private const int ABOVE_MARGIN = 5;
        private const int NEWLINE_MARGIN = 20;
        
        private readonly List<Track> _tracks;

        public UcOverzichtBs()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlTracks, new object[] { true });

            _tracks = Track.GetDefaultTracks();
        }
        

        private void DrawSections(Graphics g)
        {
            int x = LEFT_MARGIN;
            int y = ABOVE_MARGIN;
            int maxHeight = 0;

            Size ucSize = this.Size;

            foreach (Track track in _tracks)
            {
                DrawSection(g, track, x, y);

                if (maxHeight < track.GetHeight(SECTION_HEIGHT))
                {
                    maxHeight = track.GetHeight(SECTION_HEIGHT);
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

        private void DrawSection(Graphics g, Track track, int x, int y)
        {
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 12);

            g.DrawRectangle(pen, x, y, SECTION_WIDTH, SECTION_HEIGHT);
            g.DrawString(Convert.ToString(track.Number), font, brush, x, y);
            y += SECTION_HEIGHT;

            for (int i = 0; i < track.AmountSections; i++)
            {
                g.DrawRectangle(pen, x, y, SECTION_WIDTH, SECTION_HEIGHT);
                y += SECTION_HEIGHT;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawSections(e.Graphics);
        }

        private void pnlTracks_MouseClick(object sender, MouseEventArgs e)
        {
            int x = LEFT_MARGIN;
            int y = ABOVE_MARGIN;
            int maxHeight = 0;          

            foreach (Track track in _tracks)
            {
                if (e.X >= x && e.X <= x + SECTION_WIDTH && e.Y >= y && e.Y <= y + track.GetHeight(SECTION_HEIGHT))
                {
                    int y2 = y + SECTION_HEIGHT;

                    if (e.Y <= y2)
                    {
                        MessageBox.Show($"Clicked: {track.Number}");
                        break;
                    }

                    for (int i = 0; i < track.AmountSections; i++)
                    {
                        y2 += SECTION_HEIGHT;

                        if (e.Y <= y2)
                        {
                            MessageBox.Show($"Clicked: {track.Number}; Section: {i}");
                            break;
                        }
                    }
                }

                if (maxHeight < track.GetHeight(SECTION_HEIGHT))
                {
                    maxHeight = track.GetHeight(SECTION_HEIGHT);
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

        private void ucOverzichtBS_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
