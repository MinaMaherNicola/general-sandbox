using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InMemory;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args);

        host.ConfigureServices((ctx, services) =>
        {
            services.AddMassTransit(busConfigurations =>
            {
                busConfigurations.SetKebabCaseEndpointNameFormatter();
                busConfigurations.UsingInMemory((context, config) => config.ConfigureEndpoints(context));

                busConfigurations.AddConsumers(typeof(Program).Assembly);
            });

            services.AddHostedService<MessagePublisher>();
        });

        await host.StartAsync();

        Console.ReadLine();
    }
}