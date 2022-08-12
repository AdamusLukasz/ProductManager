using ProductManager.Entities;
using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        Guid CreateProduct(CreateProductDto dto);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(Guid id);
        void UpdateProduct(Guid id, UpdateProductDto dto);
        void DeleteProduct(Guid id);
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
                ShopId = dto.ShopId,
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

        public void DeleteProduct(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product is null) throw new Exception("Not Found.");

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
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
            if (products is null) throw new Exception("Not Found.");
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
            if (product is null) throw new Exception("Not Found.");
            return product;
        }
        public void UpdateProduct(Guid id, UpdateProductDto dto)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product is null) throw new Exception("Not Found.");


            product.Quantity = dto.Quantity;
            product.Description = dto.Description;

            _dbContext.SaveChanges();
        }
    }
}
