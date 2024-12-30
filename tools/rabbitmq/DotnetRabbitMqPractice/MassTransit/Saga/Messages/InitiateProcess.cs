namespace Saga.Messages;

public record InitiateProcess(Guid CorrelationId, string InitiateMessage = "Initiate");