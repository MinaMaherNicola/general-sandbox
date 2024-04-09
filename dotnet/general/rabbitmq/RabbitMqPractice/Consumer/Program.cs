using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

public static class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        Console.WriteLine("Consumer waiting for messages");

        var consumer = new EventingBasicConsumer(channel);
        
        consumer.Received += (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            Console.WriteLine($"Consumer received: {Encoding.UTF8.GetString(body)}");
        };

        channel.BasicConsume(queue: "Hello", autoAck: true, consumer: consumer);
        
    }
}