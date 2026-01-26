using System.Net;

namespace SagiCore.Exceptions.ExceptionsBase
{
    [Serializable]
    public class InvalidLoginException : SagiCoreException
    {
        public InvalidLoginException() : base(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID)
        {
        }

    }
}
