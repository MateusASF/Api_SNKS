using Api_SNKS.Core.Models;


namespace Api_SNKS.Core.Intrerfaces.Shops
{
    public interface IShopRepository
    {
        Task <Shop> GetShopUserAsync(string id);
    }
}
