using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.Producers;
using Saga.Sagas;

namespace Saga;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args);

        host.ConfigureServices((_, services) =>
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddSagaStateMachine<ProcessSagaStateMachine, ProcessSagaInstance>()
                    .InMemoryRepository();
                
                cfg.UsingRabbitMq((mqCtx, mq) =>
                {
                    mq.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    
                    mq.ConfigureEndpoints(mqCtx);
                });
                
                cfg.AddConsumers(Assembly.GetEntryAssembly());
            });
            services.AddHostedService<InitiateProcessProducer>();
        });
        
        await host.StartAsync();

        Console.ReadLine();
    }
}