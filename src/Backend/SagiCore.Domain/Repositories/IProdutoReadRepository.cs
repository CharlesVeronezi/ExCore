namespace SagiCore.Domain.Repositories
{
    public interface IProdutoReadRepository
    {
        public Task<bool> ExisteProdutoComCodproRepetido(string codpro, string subcod);
    }
}
