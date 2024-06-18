using Cashato.DB.Contracts;
using Cashato.DB.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashato.DB.Models
{
    public class Account : AuditEntity
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
        public AccountTypeEnum Type { get; set; }
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;
    }
}
