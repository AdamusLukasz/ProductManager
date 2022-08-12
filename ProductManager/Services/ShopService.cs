using Microsoft.EntityFrameworkCore;
using ProductManager.Entities;
using ProductManager.Models;
using ProductManager.Services.Interfaces;

namespace ProductManager.Services
{

    public class ShopService : IShopService
    {
        private readonly ProductDbContext _dbContext;
        public ShopService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateShop(CreateShopDto dto)
        {
            var product = new Shop()
            {
                Name = dto.Name,
                Address = new Address { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }
            };
            _dbContext.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }
        public IEnumerable<ShopDto> GetAll()
        {
            var shops = _dbContext
                .Shops
                .Include(x => x.Address)
                .Include(x => x.Products)
                .Select(s => new ShopDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.Address.PostalCode,
                    Street = s.Address.Street,
                    City = s.Address.City,
                    Products = s.Products.Select(y => new ProductDto 
                    { Id = y.Id, Name = y.Name, Number = y.Number, Description = y.Description, Quantity = y.Quantity, Price = y.Price }).ToList()
                });
            if (shops is null) throw new Exception("Not Found.");
            return shops;
        }
        public ShopDto GetById(int id)
        {
            var shop = _dbContext.Shops
                .Include(x => x.Address)
                .Select(z => new ShopDto()
                {
                    Id = z.Id,
                    Name = z.Name,
                    City = z.Address.City,
                    Street = z.Address.Street,
                    PostalCode = z.Address.PostalCode
                })
                .FirstOrDefault(x => x.Id == id);
            if (shop is null) throw new Exception("Not Found.");
            return shop;
        }
        public void Delete(int id)
        {
            var shop = _dbContext
                .Shops
                .Include(x => x.Address)
                .FirstOrDefault(f => f.Id == id);
            if (shop is null) throw new Exception("Not found.");
            _dbContext.Shops.Remove(shop);
            _dbContext.SaveChanges();
        }
    }
}
