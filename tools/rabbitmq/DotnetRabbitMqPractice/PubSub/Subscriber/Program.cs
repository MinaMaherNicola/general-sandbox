using System.Text;
using QueueBuilder;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

        var channel = mq.GetChannel();
        await channel.ExchangeDeclareAsync("logs", type: ExchangeType.Fanout, durable: true, autoDelete: true);

        var queue = await channel.QueueDeclareAsync();

        await channel.QueueBindAsync(queue.QueueName, "logs", string.Empty);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());

            Console.WriteLine($"Subscriber 2 received: {message}");

            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        await channel.BasicConsumeAsync(queue.QueueName, autoAck: false, consumer: consumer);

        Console.ReadLine();
    }
}