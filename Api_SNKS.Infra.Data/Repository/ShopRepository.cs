using Api_SNKS.Core.Intrerfaces.Shops;
using Api_SNKS.Core.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Api_SNKS.Infra.Data.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ShopRepository> _logger;

        public ShopRepository(IConfiguration configuration, ILogger<ShopRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<Shop> GetShopUserAsync(string idShop)
        {
            _logger.LogInformation("Chamando URL: {0}", _configuration["Api_SNKS - ShopRepository: GetShopUserAsync"]);
            var query = "SELECT * FROM shops WHERE idShop = @idShop";
            DynamicParameters parameters = new(new { idShop });
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            try
            {
                return await conn.QueryFirstOrDefaultAsync<Shop>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro inesperado na requisão da API no acesso ao Banco de Dados");
                throw;
            }
        }
    }
}
