namespace EyeCT4RailsLib
{
    public class Section
    {
        /// <summary>
        /// The id of the section in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Tram that is parked on this section. Can be null.
        /// </summary>
        public Tram Tram { get; set; }
        /// <summary>
        /// Bool determining wheter the section is blocked or not.
        /// </summary>
        public bool Blocked { get; set; }

        /// <summary>
        /// Creates a section without a tram.
        /// </summary>
        /// <param name="id">The id of the section.</param>
        /// <param name="blocked">Bool that represents wheter the section is blocked</param>
        public Section(int id, bool blocked)
        {
            Id = id;
            Blocked = blocked;
        }

        /// <summary>
        /// Creates a section with a tram parked on it.
        /// </summary>
        /// <param name="id">The id of the section.</param>
        /// <param name="blocked">Bool that represents wheter the section is blocked</param>
        /// <param name="tram">Tram that is parked on the section.</param>
        public Section(int id, bool blocked, Tram tram) : this(id, blocked)
        {
            Tram = tram;
        }
    }
}
