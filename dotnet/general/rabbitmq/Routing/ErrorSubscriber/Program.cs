using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ErrorSubscriber;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare("direct_logs", ExchangeType.Direct);
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queueName, "direct_logs", "error");
        
        Console.WriteLine("Error subscriber waiting for logs");

        var subscriber = new EventingBasicConsumer(channel);

        subscriber.Received += (_, eventArgs) =>
        {
            Console.WriteLine($"Error subscriber received: {Encoding.UTF8.GetString(eventArgs.Body.ToArray())}");
            Thread.Sleep(1000);
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: subscriber);
        
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}