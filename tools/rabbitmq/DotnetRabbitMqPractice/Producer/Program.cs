using System.Text;
using QueueBuilder;
using RabbitMQ.Client;

namespace Producer;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        await using MqBuilder builder = new();

        var channel = builder.GetChannel();

        await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
            arguments: null);
        
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        while (true)
        {
            try
            {
                Console.WriteLine("1. Press 'c' to exit");
                Console.WriteLine("2. Press 's' to send message.");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
                    await SendMessage(channel, new Random().Next(100, 1000).ToString());
                }
                else if (key.Key == ConsoleKey.C)
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch
            {
                Console.WriteLine("\nPlease, only use valid keys\n");
            }

            
        }
    }

    private static async Task SendMessage(IChannel channel, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }
        var messageInBytes = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: messageInBytes);
        Console.WriteLine("\nProducer sent one message\n");
    }
}