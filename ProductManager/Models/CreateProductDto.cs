using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class CreateProductDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = String.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
