using Microsoft.Extensions.DependencyInjection;

namespace Kernel.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddKernelApplication(this IServiceCollection services)
    {
        return services;
    } 
}