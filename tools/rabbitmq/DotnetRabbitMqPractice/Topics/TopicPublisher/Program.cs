using QueueBuilder;
using RabbitMQ.Client;

namespace TopicPublisher;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

       await using var channel = mq.GetChannel();

        await channel.ExchangeDeclareAsync("topics", ExchangeType.Topic, true, true);

        await mq.EnterSendMode("topics", string.Empty, "general.info");
    }
}