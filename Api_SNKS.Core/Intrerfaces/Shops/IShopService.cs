using Api_SNKS.Core.Models;


namespace Api_SNKS.Core.Intrerfaces.Shops
{
    public interface IShopService
    {
        Task<Shop> GetShopUserAsync(string id);
    }
}
