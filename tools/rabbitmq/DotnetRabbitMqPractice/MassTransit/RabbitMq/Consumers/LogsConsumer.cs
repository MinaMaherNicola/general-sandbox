using MassTransit;
using RabbitMq.Messages;

namespace RabbitMq.Consumers;

public class LogsConsumer : IConsumer<Log>
{
    public Task Consume(ConsumeContext<Log> context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        Console.WriteLine($"{nameof(LogsConsumer)} received {context.Message.Level}: {context.Message.Message}");

        return Task.CompletedTask;
    }
}