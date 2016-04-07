using System.Collections.Generic;

namespace EyeCT4RailsLib
{
    public class Depot
    {
        private readonly List<Track> _tracks;

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
        /// Creates a depot with an id and name.
        /// </summary>
        /// <param name="id">Id of the depot in the database.</param>
        /// <param name="name">Name of the depot.</param>
        public Depot(int id, string name)
        {
            Id = id;
            Name = name;
            _tracks = new List<Track>();
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
    }
}
