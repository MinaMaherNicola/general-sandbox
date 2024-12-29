using InMemory.Messages;
using MassTransit;

namespace InMemory;

public class MessageConsumer : IConsumer<CurrentTime>
{
    public Task Consume(ConsumeContext<CurrentTime> context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        Console.WriteLine($"{nameof(MessageConsumer)}: {context.Message.Value}");
        
        return Task.CompletedTask;
    }
}

public class MessageConsumerV2 : IConsumer<CurrentTime>
{
    public Task Consume(ConsumeContext<CurrentTime> context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        Console.WriteLine($"{nameof(MessageConsumerV2)}: {context.Message.Value}");
        
        return Task.CompletedTask;
    }
}