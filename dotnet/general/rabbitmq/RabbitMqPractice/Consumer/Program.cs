using System.Collections.ObjectModel;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

public static class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "Hello", durable: true, exclusive: false, autoDelete: false, arguments: null);

        Console.WriteLine("Consumer waiting for messages");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            Console.WriteLine($"Consumer received: {Encoding.UTF8.GetString(body)}");
            channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
            Thread.Sleep(1000);
        };

        channel.BasicConsume(queue: "Hello", autoAck: false, consumer: consumer);
        
        Console.WriteLine("Press [enter] to exit.");
        Console.ReadLine();
    }
}
