using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Producer;

internal static class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection(); // this abstracts the socket connection, authentication, negotiation, and so on
        using var channel = connection.CreateModel(); // this is where most of the API resides
        
        // this will only create the queue if it doesn't exist
        channel.QueueDeclare(queue: "hello", // queue name
            durable: false, // determines if the queue should survive a rabbitmq restart (will be stored on disk)
            exclusive: false, // specifies whether the queue is only accessible by the connection that declares it
            autoDelete: false, // deletes the queue when there are no consumers attached
            arguments: null); // advanced settings
        
        const string message = "Bagolak Alooh";
        var body = Encoding.UTF8.GetBytes(message);
        
        channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);

        Console.WriteLine("Producer sent!");
    }
}