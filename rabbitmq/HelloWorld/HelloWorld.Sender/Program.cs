using System.Text;
using RabbitMQ.Client;

namespace HelloWorld.Sender;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        
        // the connection abstracts the socket connection and takes care of protocol version negotiation and authentication.
        using var connection = factory.CreateConnection();
        
        // the channel is where most of the API for getting things done resides
        using var channel = connection.CreateModel();

        const string queueName = "hello_queue";
        
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);

        const string message = "Hello world, from sender!";
        
        channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: null, body: Encoding.UTF8.GetBytes(message));

        Console.WriteLine("Sender published something to a queue");
    }
}