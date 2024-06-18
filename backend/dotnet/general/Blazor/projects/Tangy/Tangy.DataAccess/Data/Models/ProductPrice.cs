using System.ComponentModel.DataAnnotations.Schema;
using Tangy.DataAccess.Contracts;

namespace Tangy.DataAccess.Data.Models
{
    public class ProductPrice : BaseEntity
    {
        [ForeignKey(nameof(Models.Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public string Size { get; set; } = null!;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
