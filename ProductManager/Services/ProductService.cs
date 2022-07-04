using ProductManager.Entities;
using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        public int CreateProduct(CreateProductDto dto);
        public IEnumerable<ProductDto> GetAll();
    }
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateProduct(CreateProductDto dto)
        {
            var product = new Product()
            {
                Name = dto.Name,
                Number = dto.Number,
                Quantity = dto.Quantity,
                Description = dto.Description,
                Price = dto.Price
            };
            _dbContext.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            var products = _dbContext
                .Products
                .Select(s => new ProductDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Number = s.Number,
                    Description = s.Description,
                    Quantity = s.Quantity,
                    Price = s.Price
                });

            return products;
        }
    }
}
