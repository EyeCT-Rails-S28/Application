using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// General collection exception for capturing all exceptions that relate to the database.
    /// </summary>
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
