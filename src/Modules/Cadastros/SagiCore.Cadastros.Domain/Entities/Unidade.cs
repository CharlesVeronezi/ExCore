namespace SagiCore.Cadastros.Domain.Entities;

public sealed class Unidade
{
    public string Un { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;

    private Unidade() { }
}