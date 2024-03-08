using System.ComponentModel.DataAnnotations;

namespace Tangy.Models.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        public string Name { get; set; } = null!;
    }
}
