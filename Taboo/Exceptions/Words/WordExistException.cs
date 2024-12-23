namespace Taboo.Exceptions.Words
{
    public class WordExistException:Exception,IBaseException
    {
        int IBaseException.StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public WordExistException()
        {
            ErrorMessage = "Word already exists";
        }

        public WordExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
