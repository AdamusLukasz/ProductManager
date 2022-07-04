using Microsoft.AspNetCore.Mvc;
using ProductManager.Entities;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            var id = _productService.CreateProduct(dto);
            return Created($"/api/products/{id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }
    }
}
