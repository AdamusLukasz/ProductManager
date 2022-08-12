using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services.Interfaces;

namespace ProductManager.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateShopDto dto)
        {
            var id = _shopService.CreateShop(dto);
            return Created($"/api/shops/{id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ShopDto>> GetAll()
        {
            var shops = _shopService.GetAll();
            return Ok(shops);
        }
    }
}
