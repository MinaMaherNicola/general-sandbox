using System.Collections.ObjectModel;
using System.Text;
using RabbitMQ.Client;

namespace Producer;

public static class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "Hello", durable: true, exclusive: false, autoDelete: false, arguments: null);

        const string message = "Hello from producer ";

        for (int i = 0; i < 40; i++)
        {
            channel.BasicPublish(exchange: string.Empty, routingKey: "Hello", basicProperties: null, body: Encoding.UTF8.GetBytes(message + i));
        }
        
        Console.WriteLine("Producers sent a message");
    }
}