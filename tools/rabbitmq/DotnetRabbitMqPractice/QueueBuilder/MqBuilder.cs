using RabbitMQ.Client;

namespace QueueBuilder;

public class MqBuilder : IAsyncDisposable
{
    private readonly IConnection _connectionFactory;
    private readonly IChannel _channel;

    public MqBuilder()
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost",
        };
        
        _connectionFactory = factory.CreateConnectionAsync().Result;
        _channel = _connectionFactory.CreateChannelAsync().Result;
    }
    
    public IChannel GetChannel()
    {
        return _channel;
    }

    public async ValueTask DisposeAsync()
    {
        await _connectionFactory.DisposeAsync();
        await _channel.DisposeAsync();
        
        GC.SuppressFinalize(this);
    }
}