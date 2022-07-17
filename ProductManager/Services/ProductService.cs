using ProductManager.Entities;
using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        public Guid CreateProduct(CreateProductDto dto);
        public IEnumerable<ProductDto> GetAll();
        public ProductDto GetById(Guid id);
        public void UpdateProduct(Guid id, UpdateProductDto dto);
    }
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid CreateProduct(CreateProductDto dto)
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
        public ProductDto GetById(Guid id)
        {
            var product = _dbContext.Products.Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                Description = x.Description,
                Quantity = x.Quantity,
                Price = x.Price
            }).FirstOrDefault(d => d.Id == id);
            return product;
        }
        public void UpdateProduct(Guid id, UpdateProductDto dto)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            product.Quantity = dto.Quantity;
            product.Description = dto.Description;

            _dbContext.SaveChanges();
        }
    }
}
