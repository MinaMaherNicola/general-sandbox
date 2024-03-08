using System.ComponentModel.DataAnnotations.Schema;
using Tangy.DataAccess.Contracts;

namespace Tangy.DataAccess.Data.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool ShopFavorite { get; set; }
        public bool CustomerFavorite { get; set; }
        public string Color { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        [ForeignKey(nameof(Models.Category))]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductPrice> ProductPrices { get; } = null!;
    }
}
