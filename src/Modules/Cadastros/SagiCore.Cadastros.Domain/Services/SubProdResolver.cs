namespace SagiCore.Cadastros.Domain.Services;

public static class SubProdResolver
{
    public static string Resolver(string subcod) 
        => subcod?.Trim().ToUpperInvariant() == "F" ? "FARDO" : "SOLTO";
}