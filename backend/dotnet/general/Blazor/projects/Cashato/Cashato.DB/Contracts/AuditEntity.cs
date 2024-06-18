namespace Cashato.DB.Contracts
{
    public class AuditEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? EditedOn { get; set; } = null;
    }
}
