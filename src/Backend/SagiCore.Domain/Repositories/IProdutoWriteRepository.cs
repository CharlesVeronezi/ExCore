namespace SagiCore.Domain.Repositories
{
    public interface IProdutoWriteRepository
    {
        public Task Add(Entities.Produto produto);
    }
}
