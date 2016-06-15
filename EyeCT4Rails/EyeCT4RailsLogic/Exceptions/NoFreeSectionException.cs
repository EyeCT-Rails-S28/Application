using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// Exception that is raised when there are no free sections in the depot.
    /// </summary>
    public class NoFreeSectionException : CustomException
    {
        public NoFreeSectionException(string message) : base(message)
        {
        }
    }
}
