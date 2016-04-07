using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsUI.Forms.UserControls
{
    class Track
    {
        private readonly int _number;
        private readonly int _amountSections;

        public Track(int number, int amountSections)
        {
            _number = number;
            _amountSections = amountSections;
        }

        public void Draw(Graphics gr, int x, int y, int sectionWidth, int sectionHeight)
        {
            
        }

        public int GetHeight(int sectionHeight)
        {
            return (_amountSections + 1) * sectionHeight;
        }

        public int Number
        {
            get { return _number; }
        }

        public int AmountSections
        {
            get { return _amountSections; }
        }

        public static List<Track> GetDefaultTracks()
        {
            List<Track> tracks = new List<Track>();
            Random r = new Random();

            for (int i = 0; i < 30; i++)
            {
                tracks.Add(new Track(i, r.Next(1, 6)));
            }

            return tracks;
        }

    }
}
