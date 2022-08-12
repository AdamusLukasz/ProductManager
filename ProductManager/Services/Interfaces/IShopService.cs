using ProductManager.Models;

namespace ProductManager.Services.Interfaces
{
    public interface IShopService
    {
        int CreateShop(CreateShopDto dto);
        IEnumerable<ShopDto> GetAll();
        ShopDto GetById(int id);
        void Delete(int id);
    }
}
