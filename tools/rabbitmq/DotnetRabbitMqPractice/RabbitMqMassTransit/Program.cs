using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMqMassTransit.Consumers;

namespace RabbitMqMassTransit;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args);

        host.ConfigureServices((_, services) =>
        {
            services.AddMassTransit(configurations =>
            {
                configurations.SetKebabCaseEndpointNameFormatter();

                configurations.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("errors-queue", eq =>
                    {
                        eq.AutoDelete = true;
                        eq.Durable = false;
                        eq.PrefetchCount = 5;
                        eq.Bind(Constants.ExchangeName, exchange =>
                        {
                            exchange.RoutingKey = "error";
                            exchange.ExchangeType = ExchangeType.Direct;
                            exchange.AutoDelete = true;
                            exchange.Durable = false;
                        });


                        eq.ConfigureConsumer<ErrorsConsumer>(ctx);
                    });

                    cfg.ReceiveEndpoint("logs-queue", lq =>
                    {
                        lq.AutoDelete = true;
                        lq.Durable = false;
                        lq.PrefetchCount = 1;
                        lq.Bind(Constants.ExchangeName, exchange =>
                        {
                            exchange.RoutingKey = "other";
                            exchange.ExchangeType = ExchangeType.Direct;
                            exchange.AutoDelete = true;
                            exchange.Durable = false;
                        });

                        lq.ConfigureConsumer<LogsConsumer>(ctx);
                    });
                    cfg.ConfigureEndpoints(ctx);
                });

                configurations.AddConsumers(Assembly.GetEntryAssembly());
            });
            services.AddHostedService<LogEmitter>();
        });

        await host.StartAsync();

        Console.ReadLine();
    }
}