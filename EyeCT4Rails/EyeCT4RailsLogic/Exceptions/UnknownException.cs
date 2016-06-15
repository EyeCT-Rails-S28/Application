using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// General exception collection for exceptions which are unexpected.
    /// </summary>
    public class UnknownException : Exception
    {
        public UnknownException(string message) : base(message)
        {
        }
    }
}
