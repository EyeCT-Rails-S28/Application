using EyeCT4RailsLib;

namespace EyeCT4RailsLib.Classes
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
        public Tram Tram { get; }

        /// <summary>
        /// Bool determining wheter the section is blocked or not.
        /// </summary>
        public bool Blocked { get; }

        /// <summary>
        /// The section that comes after this section. Can be null.
        /// </summary>
        public Section NextSection { get; private set; }

        /// <summary>
        /// The section that comes before this section. Can be null.
        /// </summary>
        public Section PreviousSection { get; private set; }

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

        /// <summary>
        /// Adds a next section to a section.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public bool AddNextSection(Section section)
        {
            if (NextSection != null)
                return false;

            NextSection = section;
            return true;
        }

        public bool AddPreviousSection(Section section)
        {
            if (PreviousSection != null)
                return false;

            PreviousSection = section;
            return true;
        }

        public override string ToString()
        {
            string blocked = Blocked ? "Blocked" : "Not Blocked";
            string tram = Tram?.Id.ToString();
            if (Tram == null)
                tram = "No Tram";

            return $"{Id} - {blocked} - {tram}";
        }
    }
}