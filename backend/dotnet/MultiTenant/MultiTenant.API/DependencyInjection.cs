﻿using Identity.Api;
using Kernel.Api;

namespace MultiTenant.API;

public static class DependencyInjection
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddIdentityModule(configuration)
            .AddKernelModule(configuration);
    }
}