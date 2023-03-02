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


        public async Task<User> GetProfileUserAsync(string idEvent)
        {
            _logger.LogInformation("Chamando URL: {0}", _configuration["APIEvents - CityEventRepository: ConsultarEventosidAsync"]);
            var query = "SELECT * FROM CityEvent WHERE idEvent = @idEvent";
            DynamicParameters parameters = new(new { idEvent });
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
