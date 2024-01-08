using System.ComponentModel.DataAnnotations;

namespace Tangy.Models.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public bool ShopFavorite { get; set; }
        public bool CustomerFavorite { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public Guid? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
