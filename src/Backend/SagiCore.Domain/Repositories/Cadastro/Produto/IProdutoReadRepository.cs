namespace SagiCore.Domain.Repositories.Cadastro.Produto
{
    public interface IProdutoReadRepository
    {
        public Task<bool> ExisteProdutoComCodproRepetido(string codpro, string subcod);
    }
}
