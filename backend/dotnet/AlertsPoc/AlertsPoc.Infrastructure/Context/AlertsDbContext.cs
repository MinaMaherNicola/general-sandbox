using AlertsPoc.Application.Context;
using AlertsPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlertsPoc.Infrastructure.Context;

public sealed class AlertsDbContext(DbContextOptions<AlertsDbContext> options) : DbContext(options), IAlertsDbContext
{
    public required DbSet<Alert> Alerts { get; init; }
    public required DbSet<SocAnalyst> Analysts { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlertsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}