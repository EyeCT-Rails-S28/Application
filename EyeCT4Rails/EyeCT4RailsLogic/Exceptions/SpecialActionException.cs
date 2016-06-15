using System;

namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// Exception that is raised whenever there is a special action required by the depot manager.
    /// </summary>
    public class SpecialActionException : Exception
    {
        public SpecialActionException(string message) : base(message)
        {
            
        }
    }
}
