using Api_SNKS.Core.Intrerfaces.Shop;
using Api_SNKS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_SNKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }


        [HttpGet("/shop/shop{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Shop>> GetShopUserAsync(string id)
        {
            var shop = await _shopService.GetShopUserAsync(id);
            if (shop == null)
            {
                return BadRequest("Compra não encontrada");
            }
            return Ok(shop);
        }
    }
}
