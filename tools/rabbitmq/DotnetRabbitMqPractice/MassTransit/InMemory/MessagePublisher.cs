using InMemory.Messages;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace InMemory;

public class MessagePublisher(IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(5000, stoppingToken);
            await bus.Publish(new CurrentTime($"The current time is {DateTime.Now}"), stoppingToken);
            Console.WriteLine("Publisher published the current time");
        }
    }
}