using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SagiCore.Shared.Application.User;

namespace SagiCore.Shared.Infrastructure.User
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated() => _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

        public int GetIdEmpresa()
        {
            var claim = _httpContextAccessor.HttpContext?.User.FindFirst("IdEmpresa")?.Value;
            if (int.TryParse(claim, out var id))
                return id;

            throw new UnauthorizedAccessException("Tenant ID (IdEmpresa) não encontrado no token.");
        }

        public string GetUserEmail()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
        }
    }
}
