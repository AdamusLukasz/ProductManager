using System.ComponentModel.DataAnnotations;

namespace ProductManager.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Shop? Shop { get; set; }
        public int ShopId { get; set; }
    }
}
