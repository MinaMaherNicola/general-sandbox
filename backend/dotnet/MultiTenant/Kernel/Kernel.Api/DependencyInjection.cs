using Kernel.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kernel.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddKernelModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddKernelInfrastructure(configuration);
    }
}