namespace Taboo.Exceptions.BannedWords
{
    public class BannedWordExistException:Exception,IBaseException
    {
        int IBaseException.StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public BannedWordExistException()
        {
            ErrorMessage = "Banned word already exists";
        }

        public BannedWordExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
