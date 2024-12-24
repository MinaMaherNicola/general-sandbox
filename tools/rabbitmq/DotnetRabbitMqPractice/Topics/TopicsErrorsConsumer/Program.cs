using System.Text;
using QueueBuilder;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TopicsErrorsConsumer;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using var mq = new RabbitMq();

        var channel = mq.GetChannel();
        
        await channel.ExchangeDeclareAsync("topics", ExchangeType.Topic, true, true);

        var queue = await channel.QueueDeclareAsync();

        await channel.BasicQosAsync(0, 1, false);

        await channel.QueueBindAsync(queue.QueueName, "topics", "#.error");

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());

            Console.WriteLine($"Error Consumer: {message}");

            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        await channel.BasicConsumeAsync(queue.QueueName, false, consumer);
        
        Console.ReadLine();
    }
}