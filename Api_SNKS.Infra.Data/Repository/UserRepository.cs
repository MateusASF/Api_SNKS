using Api_SNKS.Core.Intrerfaces.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Dapper;
using Api_SNKS.Core.Models;

namespace Api_SNKS.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<User> GetProfileUserAsync(string iduser)
        {
            _logger.LogInformation("Chamando URL: {0}", _configuration["Api_SNKS - UserRepository: GetProfileUserAsync"]);
            var query = "SELECT * FROM users WHERE id = @iduser";
            DynamicParameters parameters = new(new { iduser });
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            try
            {
                return await conn.QueryFirstOrDefaultAsync<User>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro inesperado na requisão da API no acesso ao Banco de Dados");
                throw;
            }
        }
    }
}
