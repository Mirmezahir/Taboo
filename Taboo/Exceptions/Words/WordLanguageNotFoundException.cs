namespace Taboo.Exceptions.Words
{
    public class WordLanguageNotFoundException:Exception, IBaseException
    {
        int IBaseException.StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public WordLanguageNotFoundException()
        {
            ErrorMessage = "Word language not found";
        }

        public WordLanguageNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
    
    
}
