namespace SagiCore.Domain.Repositories.Cadastro.Produto
{
    public interface IProdutoWriteRepository
    {
        public Task Add(Entities.Cadastro.Produto produto);
    }
}
