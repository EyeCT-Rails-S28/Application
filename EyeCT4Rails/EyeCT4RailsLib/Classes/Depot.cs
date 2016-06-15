using System.Collections.Generic;
using EyeCT4RailsLib;

namespace EyeCT4RailsLib.Classes
{
    public class Depot
    {
        private readonly List<Track> _tracks;

        private readonly List<Tram> _trams; 

        /// <summary>
        /// The id in the database of the depot.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The name of the depot.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The tracks the depot has.
        /// </summary>
        public List<Track> Tracks => new List<Track>(_tracks);

        /// <summary>
        /// The trams the depot has.
        /// </summary>
        public List<Tram> Trams => new List<Tram>(_trams); 
        /// <summary>
        /// Creates a depot with an id and name.
        /// </summary>
        /// <param name="id">Id of the depot in the database.</param>
        /// <param name="name">Name of the depot.</param>
        public Depot(int id, string name)
        {
            Id = id;
            Name = name;
            _tracks = new List<Track>();
            _trams = new List<Tram>();
        }

        /// <summary>
        /// Adds a track to the depot. Checks for duplicate tracks.
        /// </summary>
        /// <param name="track">Track that could be added.</param>
        public void AddTrack(Track track)
        {
            if (!_tracks.Contains(track))
                _tracks.Add(track);
        }

        /// <summary>
        /// Adds a tram to the depot.
        /// </summary>
        /// <param name="tram">The new tram.</param>
        public void AddTram(Tram tram)
        {
            if (!_trams.Contains(tram))
            {
                _trams.Add(tram);
            }
        }

        /// <summary>
        /// ToString method of the depot class.
        /// </summary>
        /// <returns>Returns the name of the depot.</returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
