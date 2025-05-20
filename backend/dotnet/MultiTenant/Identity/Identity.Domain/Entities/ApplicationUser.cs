using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public sealed class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Used to partition users by tenant.
    /// </summary>
    public required Guid TenantId { get; init; }
}