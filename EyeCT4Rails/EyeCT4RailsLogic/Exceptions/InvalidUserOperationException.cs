namespace EyeCT4RailsLogic.Exceptions
{
    /// <summary>
    /// General exception for when the user tries to do an operation that cannot be executed.
    /// </summary>
    public class InvalidUserOperationException : CustomException
    {
        public InvalidUserOperationException(string message) : base(message)
        {
            
        }
    }
}
