namespace SagiCore.Shared.Domain.Entities
{
    public abstract class EntityBase
    {
        public DateTime CriadoEm { get; protected set; } = DateTime.UtcNow;
        public DateTime? AtualizadoEm { get; protected set; }
        public string? CriadoPor { get; protected set; }
        public string? AtualizadoPor { get; protected set; }

        public void MarcarComoAtualizado(string? usuario = null)
        {
            AtualizadoEm = DateTime.UtcNow;
            AtualizadoPor = usuario;
        }
    }
}