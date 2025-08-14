using Identity.Application.Context;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence;

public sealed class IdentityContext(DbContextOptions<IdentityContext> options)
    : IdentityDbContext<ApplicationUser>(options), IIdentityDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);
        
        builder.HasDefaultSchema("Identity");
        
        base.OnModelCreating(builder);
    }
}