namespace Saga.Messages;

public record StepTwo(Guid CorrelationId, string StepTwoMessage = "Step Two");