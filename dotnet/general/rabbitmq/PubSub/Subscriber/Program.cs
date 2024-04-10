using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber;

internal class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare("logs", ExchangeType.Fanout);
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queueName, exchange: "logs", routingKey: string.Empty);
        Console.WriteLine("Waiting for logs");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (_, eventArgs) =>
        {
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            Console.WriteLine($"Subscriber received log: {message}");
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}