using Tangy.DataAccess.Contracts;

namespace Tangy.DataAccess.Data.Models
{
    public class Category : AuditEntity
    {
        public string Name { get; set; } = null!;
    }
}
