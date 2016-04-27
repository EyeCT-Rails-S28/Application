using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib
{
    public class Tram
    {
        /// <summary>
        /// The id of the tram in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The type of the tram.
        /// </summary>
        public TramType TramType { get; }
        /// <summary>
        /// Current status of the tram.
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// The preferred line of the tram.
        /// </summary>
        public Line PreferredLine { get; }
        /// <summary>
        /// Bool indicating wheter the tram has to ride on it's preferred line.
        /// </summary>
        public bool HasForcedLine { get; }

        /// <summary>
        /// Creates a tram.
        /// </summary>
        /// <param name="id">The id of the tram in the database.</param>
        /// <param name="status">The status of the tram.</param>
        /// <param name="preferredLine">Preferred line of the tram.</param>
        /// <param name="hasForcedLine">Bool indicating wheter the line is forced.</param>
        public Tram(int id, TramType type, Status status, Line preferredLine, bool hasForcedLine)
        {
            Id = id;
            TramType = type;
            Status = status;
            PreferredLine = preferredLine;
            HasForcedLine = hasForcedLine;
        }

        public override string ToString()
        {
            return $"{Id} - {Status}";
        }
    }
}
