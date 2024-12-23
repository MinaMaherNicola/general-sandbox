using System.Text;
using QueueBuilder;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LogsConsumer;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

        var channel = mq.GetChannel();

        await channel.ExchangeDeclareAsync("logs", type: ExchangeType.Direct, durable: true, autoDelete: false);
        
        var queue = await channel.QueueDeclareAsync();

        await channel.QueueBindAsync(queue.QueueName, "logs", "error");
        
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());

            Console.WriteLine($"Error consumer received: {message}");

            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        await channel.BasicConsumeAsync(queue.QueueName, autoAck: false, consumer: consumer);

        Console.ReadKey();
    }
}