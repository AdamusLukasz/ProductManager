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
        [HttpGet("{id}")]
        public ActionResult<ShopDto> Get([FromRoute] int id)
        {
            var shop = _shopService.GetById(id);
            return shop;
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteShop([FromRoute] int id)
        {
            _shopService.Delete(id);
            return NoContent();
        }
    }
}
