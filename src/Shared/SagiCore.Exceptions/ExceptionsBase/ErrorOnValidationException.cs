namespace SagiCore.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : SagiCoreException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
