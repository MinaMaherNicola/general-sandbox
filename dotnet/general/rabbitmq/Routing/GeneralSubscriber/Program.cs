using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GeneralSubscriber;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare("direct_logs", ExchangeType.Direct);
        var queueName = channel.QueueDeclare();
        channel.QueueBind(queueName, "direct_logs", "info");

        Console.WriteLine("Info subscriber waiting for logs");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (_, eventArgs) =>
        {
            Console.WriteLine($"Info subscriber received {Encoding.UTF8.GetString(eventArgs.Body.ToArray())}");
            Thread.Sleep(1000);
        };

        channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}