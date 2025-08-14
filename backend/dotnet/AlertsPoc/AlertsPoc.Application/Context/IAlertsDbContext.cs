using AlertsPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlertsPoc.Application.Context;

public interface IAlertsDbContext
{
    DbSet<Alert> Alerts { get; init; }
    DbSet<SocAnalyst> Analysts { get; init; }
}