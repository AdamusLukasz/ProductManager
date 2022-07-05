using System.ComponentModel.DataAnnotations;

namespace ProductManager.Entities
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        public int Number { get; set; }
        public int Quantity { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
