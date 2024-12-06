using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

using QueueBuilder;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using MqBuilder builder = new();

        var channel = builder.GetChannel();
        
        await channel.QueueDeclareAsync(queue: "hello", false, false, false, arguments: null);

        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, @event) =>
        {
            string message = Encoding.UTF8.GetString(@event.Body.ToArray());

            Console.WriteLine($"Consumer 2 received {message}");

            await Task.Delay(2000);

            await channel.BasicAckAsync(@event.DeliveryTag, false);
        };

        await channel.BasicConsumeAsync("hello", autoAck: false, consumer: consumer);
        
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}