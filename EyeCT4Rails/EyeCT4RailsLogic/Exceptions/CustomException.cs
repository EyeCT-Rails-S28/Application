using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// An exception that will be caught and rethrown be the FilterCustomException method.
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
