using System.Reflection;
using Identity.Api;
using Kernel.Api;
using Microsoft.EntityFrameworkCore;

namespace MultiTenant.API;

public static class DependencyInjection
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddIdentityModule(configuration)
            .AddKernelModule(configuration);
    }

    public static async Task MigrateAsync(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        
        var services = scope.ServiceProvider;
    
        var dbContextTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => 
                typeof(DbContext).IsAssignableFrom(t) 
                && !t.IsAbstract
                && services.GetService(t) is not null);
    
        foreach (var ctxType in dbContextTypes)
        {
            var ctx = (DbContext)services.GetRequiredService(ctxType);
            await ctx.Database.MigrateAsync();
        }
    }
}