using AlertsPoc.Application.Context;
using AlertsPoc.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlertsPoc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddDbContext<AlertsDbContext>(options =>
            options.UseSqlServer(
                configurations.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                    sqlOptions.CommandTimeout(60);
                })
        );
        services.AddScoped<IAlertsDbContext, AlertsDbContext>();

        return services;
    }
}