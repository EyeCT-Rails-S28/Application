using System;
using System.Collections.Generic;
using System.Drawing;
using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    class Track
    {
        public Track(int number, int amountSections)
        {
            Number = number;
            AmountSections = amountSections;
        }

        public int GetHeight(int sectionHeight)
        {
            return (AmountSections + 1) * sectionHeight;
        }

        public int Number { get; }

        public int AmountSections { get; }

        public static List<Track> GetDefaultTracks()
        {
            List<Track> tracks = new List<Track>();
            Random r = new Random();

            for (int i = 0; i < 38; i++)
            {
                tracks.Add(new Track(i, r.Next(1, 5)));
            }

            return tracks;
        }

    }
}
