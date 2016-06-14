using System;

namespace EyeCT4RailsLogic.Exceptions
{
    public class NoFreeSectionException : CustomException
    {
        public NoFreeSectionException(string message) : base(message)
        {
        }
    }
}
