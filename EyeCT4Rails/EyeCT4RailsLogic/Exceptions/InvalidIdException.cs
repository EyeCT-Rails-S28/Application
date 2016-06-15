namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// General exception for when identifiers are incorrect.
    /// </summary>
    public class InvalidIdException : CustomException
    {
        public InvalidIdException(string message) : base(message)
        {
            
        }
    }
}
