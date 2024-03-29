﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById([FromRoute] Guid id)
        {
            var product = _productService.GetById(id);
            return product;
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromBody] UpdateProductDto dto, [FromRoute] Guid id)
        {
            _productService.UpdateProduct(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] Guid id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
