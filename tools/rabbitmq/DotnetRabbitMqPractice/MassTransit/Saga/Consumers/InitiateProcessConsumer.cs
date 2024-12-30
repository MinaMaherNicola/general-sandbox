using MassTransit;
using Saga.Messages;

namespace Saga.Consumers;

public class InitiateProcessConsumer() : IConsumer<InitiateProcess>
{
    public Task Consume(ConsumeContext<InitiateProcess> context)
    {
        Console.WriteLine($"{nameof(InitiateProcessConsumer)}: {context.Message.InitiateMessage} - {context.Message.CorrelationId}");

        return Task.CompletedTask;
    }
}