using System;

namespace EyeCT4RailsLogic.Exceptions
{
    public class UnknownException : Exception
    {
        public UnknownException(string message) : base(message)
        {
        }
    }
}
