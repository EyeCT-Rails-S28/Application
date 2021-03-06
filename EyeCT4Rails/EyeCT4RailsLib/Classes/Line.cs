﻿using EyeCT4RailsLib;

namespace EyeCT4RailsLib.Classes
{
    public class Line
    {
        /// <summary>
        /// The id of the line in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The line that is associated with this line. Can be null.
        /// </summary>
        public Line AssociatedLine { get; }

        /// <summary>
        /// Creates a line.
        /// </summary>
        /// <param name="id">The id of the line.</param>
        public Line(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a line.
        /// </summary>
        /// <param name="id">The id of the line.</param>
        /// <param name="associatedLine">The line that is associated with this line.</param>
        public Line(int id, Line associatedLine) : this(id)
        {
            AssociatedLine = associatedLine;
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
