using QueueBuilder;
using RabbitMQ.Client;

namespace LogsPublisher;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

        await using var channel = mq.GetChannel();

        await channel.ExchangeDeclareAsync("logs", type: ExchangeType.Direct, durable: true, autoDelete: false);

        await mq.EnterSendMode("logs", string.Empty, "error");
    }
}