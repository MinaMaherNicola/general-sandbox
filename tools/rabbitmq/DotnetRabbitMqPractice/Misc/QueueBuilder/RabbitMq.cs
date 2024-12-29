using System.Text;
using RabbitMQ.Client;

namespace QueueBuilder;

public class RabbitMq : IAsyncDisposable
{
    private readonly IConnection _connection;
    private readonly IChannel _channel;

    public RabbitMq()
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost",
        };
        
        _connection = factory.CreateConnectionAsync().Result;
        _channel = _connection.CreateChannelAsync().Result;
    }
    
    public IChannel GetChannel()
    {
        return _channel;
    }

    public async Task EnterSendMode(string exchangeName, string queueName, string? routingKey = null)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("1. Press 'c' to exit");
                Console.WriteLine("2. Press 's' to send message.");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
                    await SendMessage(exchangeName, queueName, new Random().Next(100, 1000).ToString(), routingKey);
                }
                else if (key.Key == ConsoleKey.C)
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch
            {
                Console.WriteLine("\nPlease, only use valid keys\n");
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _connection.DisposeAsync();
        await _channel.DisposeAsync();
        
        GC.SuppressFinalize(this);
    }
    
    private async Task SendMessage(string exchangeKey, string queueName, string message, string? routingKey = null)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }
        var messageInBytes = Encoding.UTF8.GetBytes(message);

        await _channel.BasicPublishAsync(exchange: exchangeKey, routingKey: string.IsNullOrWhiteSpace(routingKey) ? queueName : routingKey, body: messageInBytes);
        Console.WriteLine("\nProducer sent one message\n");
    }
}