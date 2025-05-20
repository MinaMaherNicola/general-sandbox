using Kernel.Application;
using Kernel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kernel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddKernelInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddKernelApplication()
            .AddKernelPersistence(configuration);
    }

    private static IServiceCollection AddKernelPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<SharedDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SharedConnection"), o =>
            {
                o.MigrationsAssembly(typeof(SharedDbContext).Assembly.FullName);
                o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: "Shared");
            });
        });
    }
}