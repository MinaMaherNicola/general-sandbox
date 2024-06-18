using System.ComponentModel.DataAnnotations;

namespace Tangy.Models.DTOs
{
    public class ProductPriceDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        [Required]
        public string Size { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
    }
}
