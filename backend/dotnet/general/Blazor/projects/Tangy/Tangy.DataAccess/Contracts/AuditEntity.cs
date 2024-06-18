namespace Tangy.DataAccess.Contracts
{
    public class AuditEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? EditedDate { get; set; } = null;
    }
}
