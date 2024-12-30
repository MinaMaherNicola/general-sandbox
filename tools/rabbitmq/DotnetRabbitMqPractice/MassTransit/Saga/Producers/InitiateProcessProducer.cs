using MassTransit;
using Microsoft.Extensions.Hosting;
using Saga.Messages;

namespace Saga.Producers;

public class InitiateProcessProducer(IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await bus.Publish(new InitiateProcess(Guid.NewGuid()), stoppingToken);
            Console.WriteLine("----> Producer initiated the process.");
            await Task.Delay(10000, stoppingToken);
        }
    }
}