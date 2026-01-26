namespace SagiCore.Exceptions.ExceptionsBase
{
    [Serializable]
    public class ErrorOnValidationException : SagiCoreException
    {
        public List<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            ErrorMessages = errorMessages;
        }
    }
}
