using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SagiCore.Auth.Application.Services;
using SagiCore.Auth.Infrastructure.Security;
using SagiCore.Communication.Requests.Auth;
using SagiCore.Communication.Responses.Auth;
using SagiCore.Exceptions.ExceptionsBase;

namespace SagiCore.Auth.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly TokenProvider _tokenProvider;

        public LoginUseCase(IConfiguration configuration, TokenProvider tokenProvider)
        {
            _configuration = configuration;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseLoginJson> Execute(RequestLoginJson request)
        {
            var connectionString = _configuration.GetConnectionString("ConnectionAutentica");
            using var conn = new NpgsqlConnection(connectionString);

            var senhaHash = LegacyHashService.ComputeMD5(request.Password);

            var sql = @"
            SELECT idempresa, usuario, email 
            FROM autentica_user 
            WHERE email = @Email AND chave = @Senha";

            var user = await conn.QueryFirstOrDefaultAsync<UserAuthDto>(sql, new { Email = request.Email, Senha = senhaHash });

            if (user == null)
            {
                throw new InvalidLoginException();
            }

            var token = _tokenProvider.Generate((int)user.IdEmpresa, user.Email, user.Usuario);

            return new ResponseLoginJson
            {
                Token = token,
            };
        }

        private class UserAuthDto
        {
            public decimal IdEmpresa { get; set; }
            public string Usuario { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
        }
    }
}
