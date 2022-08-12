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
                .Select(s => new ShopDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.Address.PostalCode,
                    Street = s.Address.Street,
                    City = s.Address.City,
                });
            if (shops is null) throw new Exception("Not Found.");
            return shops;
        }
    }
}
