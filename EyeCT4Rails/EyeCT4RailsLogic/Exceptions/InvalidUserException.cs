using System;

namespace EyeCT4RailsLogic.Exceptions
{
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
