namespace Taboo.Exceptions.Languages
{
    public class LanguageExistExceptions : Exception, IBaseException
    {
        int IBaseException.StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get;  }    
        public LanguageExistExceptions()
        {
           ErrorMessage = "Language already exists";
        }

        public LanguageExistExceptions(string? message) : base(message)
        {
            ErrorMessage = message;
        }

    }
}
