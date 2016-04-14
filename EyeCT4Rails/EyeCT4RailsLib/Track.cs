using System.Collections.Generic;

namespace EyeCT4RailsLib
{
    public class Track
    {
        private readonly List<Section> _sections;

        /// <summary>
        /// The id of the track.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The sections of the tracks.
        /// </summary>
        public List<Section> Sections => new List<Section>(_sections);

        /// <summary>
        /// Creates a track with a certain id.
        /// </summary>
        /// <param name="id">Id of the track in the database.</param>
        public Track(int id)
        {
            Id = id;
            _sections = new List<Section>();
        }

        /// <summary>
        /// Adds a section to the track. Checks for duplicates.
        /// </summary>
        /// <param name="section">Section that could be added.</param>
        public void AddSection(Section section)
        {
            if(!_sections.Contains(section))
                _sections.Add(section);
        }

        public override string ToString()
        {
            return $"{Id} - Length: {Sections.Count}";
        }
    }
}
