using System;

namespace EyeCT4RailsLogic.Exceptions
{
    public class NoFreeSectionException : Exception
    {
        public NoFreeSectionException(string message) : base(message)
        {
        }
    }
}
