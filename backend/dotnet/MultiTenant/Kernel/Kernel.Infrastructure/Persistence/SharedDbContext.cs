using Kernel.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kernel.Infrastructure.Persistence;

public class SharedDbContext(DbContextOptions<SharedDbContext> options, IConfiguration configuration)
    : DbContext(options), ISharedDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SharedConnect"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}