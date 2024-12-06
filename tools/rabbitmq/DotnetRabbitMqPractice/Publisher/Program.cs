using QueueBuilder;
using RabbitMQ.Client;

namespace Publisher;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

        var channel = mq.GetChannel();

        await channel.ExchangeDeclareAsync("logs", type: ExchangeType.Fanout, durable: true, autoDelete: true);
        
        await mq.EnterSendMode("logs", string.Empty);
    }
}