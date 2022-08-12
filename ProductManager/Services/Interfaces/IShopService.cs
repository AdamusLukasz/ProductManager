using ProductManager.Models;

namespace ProductManager.Services.Interfaces
{
    public interface IShopService
    {
        public int CreateShop(CreateShopDto dto);
        public IEnumerable<ShopDto> GetAll();
    }
}
