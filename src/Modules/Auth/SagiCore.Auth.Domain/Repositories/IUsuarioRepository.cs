using SagiCore.Auth.Domain.Entities;

namespace SagiCore.Auth.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAndPassword(string email);
    }
}
