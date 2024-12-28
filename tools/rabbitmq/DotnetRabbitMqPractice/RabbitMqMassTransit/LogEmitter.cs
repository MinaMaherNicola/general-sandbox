using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMqMassTransit.Messages;

namespace RabbitMqMassTransit;

public class LogEmitter(ISendEndpointProvider sender) : BackgroundService
{
    private readonly Random _random = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(500, stoppingToken);

            var message = _random.Next(500);
            var level = GetLevel(_random.Next(1, 4));

            var sendEndpoint = await sender.GetSendEndpoint(new Uri(Constants.ExchangeUrl));

            await sendEndpoint.Send(new Log(message.ToString(), level.level),
                ctx => ctx.SetRoutingKey(level.routing), stoppingToken);

            Console.WriteLine($"{nameof(LogEmitter)}: Message sent. Level: {level.level}");
        }
    }

    private static (string level, string routing) GetLevel(int level)
    {
        return level switch
        {
            1 => ("INFO", "other"),
            2 => ("WARNING", "other"),
            3 => ("ERROR", "error"),
            _ => throw new ArgumentOutOfRangeException(nameof(level), level, "Invalid level")
        };
    }
}