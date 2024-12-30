using MassTransit;
using Saga.Messages;

namespace Saga.Consumers;

public class StepOneConsumer : IConsumer<StepOne>
{
    public Task Consume(ConsumeContext<StepOne> context)
    {
        Console.WriteLine($"{nameof(StepOneConsumer)}: {context.Message.StepOneMessage} - {context.Message.CorrelationId}");
        
        return Task.CompletedTask;
    }
}