using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4RailsUI.Forms.UserControls;
using System.Reflection;

namespace EyeCT4RailsUI.Forms.frmBS
{
    public partial class Main : UserControl
    {
        private const int SectionWidth = 50;
        private const int SectionHeight = 50;
        private const int LeftMargin = 5;
        private const int AboveMargin = 5;
        private const int Margin = 20;

        //private Graphics _gr;
        private List<Track> _tracks;

        public Main()
        {
            InitializeComponent();
            //_gr = CreateGraphics();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlTracks, new object[] { true });

            _tracks = Track.GetDefaultTracks();
        }

        

        private void DrawSections(Graphics g)
        {
            int x = LeftMargin;
            int y = AboveMargin;
            int maxHeight = 0;

            Size ucSize = this.Size;

            foreach (Track track in _tracks)
            {
                DrawSection(g, track, x, y);

                if (maxHeight < track.GetHeight(SectionHeight))
                {
                    maxHeight = track.GetHeight(SectionHeight);
                }

                x += SectionWidth;

                if (x + SectionWidth + Margin > pnlTracks.Width)
                {
                    x = LeftMargin;
                    y += maxHeight + Margin;
                    maxHeight = 0;
                }
            }
        }

        private void DrawSection(Graphics g, Track track, int x, int y)
        {
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 12);

            g.DrawRectangle(pen, x, y, SectionWidth, SectionHeight);
            g.DrawString(Convert.ToString(track.Number), font, brush, x, y);
            y += SectionHeight;

            for (int i = 0; i < track.AmountSections; i++)
            {
                g.DrawRectangle(pen, x, y, SectionWidth, SectionHeight);
                y += SectionHeight;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawSections(e.Graphics);
        }

        private void pnlTracks_MouseClick(object sender, MouseEventArgs e)
        {
            int x = LeftMargin;
            int y = AboveMargin;
            int maxHeight = 0;

            Size ucSize = this.Size;

            foreach (Track track in _tracks)
            {
                if (e.X >= x && e.X <= x + SectionWidth && e.Y >= y && e.Y <= y + track.GetHeight(SectionHeight))
                {
                    int y2 = y + SectionHeight;
                    if (e.Y <= y2)
                    {
                        MessageBox.Show("Clicked: " + track.Number);
                        break;
                    }

                    for (int i = 0; i < track.AmountSections; i++)
                    {
                        y2 += SectionHeight;
                        if (e.Y <= y2)
                        {
                            MessageBox.Show("Clicked: " + track.Number + "; Section: " + i);
                            break;
                        }
                    }
                }

                if (maxHeight < track.GetHeight(SectionHeight))
                {
                    maxHeight = track.GetHeight(SectionHeight);
                }

                x += SectionWidth;

                if (x + SectionWidth + Margin > pnlTracks.Width)
                {
                    x = LeftMargin;
                    y += maxHeight + Margin;
                    maxHeight = 0;
                }
            }
        }
    }
}
