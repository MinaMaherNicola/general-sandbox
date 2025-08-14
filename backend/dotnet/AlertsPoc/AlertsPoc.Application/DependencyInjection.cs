using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace AlertsPoc.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()
            );
        })
        .AddMassTransit(configuration);

        return services;
    }

    private static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            
            x.AddConsumers(Assembly.GetExecutingAssembly());
            
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbit = configuration.GetSection("MassTransit:RabbitMQ");
                var host = rabbit["Host"] ?? "localhost";
                var user = rabbit["Username"] ?? "guest";
                var pass = rabbit["Password"] ?? "guest";

                cfg.Host(host, "/", h =>
                {
                    h.Username(user);
                    h.Password(pass);
                });
                
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}