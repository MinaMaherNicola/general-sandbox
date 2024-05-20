using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HelloWorld.Receiver;

class Program
{
    static void Main(string[] args)
    {
        var connectionFactory = new ConnectionFactory();

        using var connection = connectionFactory.CreateConnection();

        using var channel = connection.CreateModel();
        
        const string queueName = "hello_queue";
        
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, e) =>
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine($"Sender received {message}");
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer, consumerTag: Guid.NewGuid().ToString());
    }
}