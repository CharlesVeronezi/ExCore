namespace SagiCore.Cadastros.Domain.Entities;

public sealed class Categoria
{
    public int Codcat { get; private set; }
    public string Nivel { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;

    private Categoria() { }

    public string ObterNomeEstruturaCompleta() => Descricao; // Simplificado, lógica hierárquica no repositório
}