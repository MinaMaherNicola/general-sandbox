namespace Saga.Messages;

// public record StepOne(Guid CorrelationId, string StepOneMessage = "StepOne");

public class StepOne
{
    public Guid CorrelationId { get; set; }
    public string StepOneMessage { get; set; } = "StepOne";
}