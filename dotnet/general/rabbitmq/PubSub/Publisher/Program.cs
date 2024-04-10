using System.Text;
using RabbitMQ.Client;

namespace Publisher;

internal class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare("logs", ExchangeType.Fanout);

        for (int i = 0; i < 10; i++)
        {
            var message = $"log message {i}";
            channel.BasicPublish(exchange: "logs",
                                 routingKey: string.Empty,
                                 basicProperties: null,
                                 body: Encoding.UTF8.GetBytes(message));
        }
        Console.WriteLine("Publisher finished sending logs");
    }
}