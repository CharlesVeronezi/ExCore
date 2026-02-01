namespace SagiCore.Exceptions.ExceptionsBase;

[Serializable]
public class InvalidLoginException : SagiCoreException
{
    public InvalidLoginException() : base("Credenciais inválidas")
    {
    }
}
