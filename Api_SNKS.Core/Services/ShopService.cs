using Api_SNKS.Core.Intrerfaces.Shop;
using Api_SNKS.Core.Intrerfaces.Users;
using Api_SNKS.Core.Models;

namespace Api_SNKS.Core.Services
{
    public class ShopService : IShopService
    {
        public IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<Shop> GetShopUserAsync(string id)
        {
            return await _shopRepository.GetShopUserAsync(id);
        }
    }
}
