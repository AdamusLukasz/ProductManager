using System.ComponentModel.DataAnnotations;

namespace ProductManager.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
