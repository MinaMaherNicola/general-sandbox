using Identity.Application;
using Identity.Application.Context;
using Identity.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services)
    {
        return services.AddIdentityPersistence()
            .AddIdentityApplication();
    }

    private static IServiceCollection AddIdentityPersistence(this IServiceCollection services)
    {
        services.AddDbContext<IdentityDbContext>();

        services.AddScoped<IIdentityDbContext, IdentityDbContext>();

        return services;
    }
}