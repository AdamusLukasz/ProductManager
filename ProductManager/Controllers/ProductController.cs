using ProductManager.Entities;

namespace ProductManager.Controllers
{
    public class ProductController
    {
        interface IProductController
        {
            public IEnumerable<Product> GetProducts();
            public void GetProductId(int id);

        }

    }
}
