using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// Exception that is raised when the user is nonexistend or the given login data is incorrect.
    /// </summary>
    public class InvalidUserException : CustomException
    {
        public InvalidUserException(string message) : base(message)
        {
        }

        public InvalidUserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
