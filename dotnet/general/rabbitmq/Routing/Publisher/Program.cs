using System.Text;
using RabbitMQ.Client;

namespace Publisher;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare("direct_logs", ExchangeType.Direct);
        
        for (int i = 0; i < 10; i++)
        {
            channel.BasicPublish(exchange: "direct_logs",
                routingKey: "error",
                body: Encoding.UTF8.GetBytes($"ERROR: {i}"));
        }
        for (int i = 0; i < 10; i++)
        {
            channel.BasicPublish(exchange: "direct_logs",
                routingKey: "info",
                body: Encoding.UTF8.GetBytes($"INFO: {i}"));
        }

        Console.WriteLine("Publisher logged errors and info");
    }
}