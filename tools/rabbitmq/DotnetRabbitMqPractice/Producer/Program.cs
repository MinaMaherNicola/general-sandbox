using System.Text;
using QueueBuilder;
using RabbitMQ.Client;

namespace Producer;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using RabbitMq mq = new();

        var channel = mq.GetChannel();

        await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
            arguments: null);
        
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        await mq.EnterSendMode(string.Empty, "hello");
    }
}