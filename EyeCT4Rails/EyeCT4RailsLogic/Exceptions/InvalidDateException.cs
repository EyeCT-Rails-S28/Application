namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// Exception that is raised when a date would be invalid.
    /// </summary>
    public class InvalidDateException : CustomException
    {
        public InvalidDateException(string message) : base(message)
        {
        }
    }
}
