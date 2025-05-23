using MassTransit;
using RabbitMq.Messages;

namespace RabbitMq.Consumers;

public class ErrorsConsumer : IConsumer<Log>
{
    public Task Consume(ConsumeContext<Log> context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        
        Console.WriteLine($"{nameof(ErrorsConsumer)} received {context.Message.Level}: {context.Message.Message}");
        
        return Task.CompletedTask;
    }
}