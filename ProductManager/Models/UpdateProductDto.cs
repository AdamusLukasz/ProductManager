using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }
        public int Quantity { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = String.Empty;
    }
}
