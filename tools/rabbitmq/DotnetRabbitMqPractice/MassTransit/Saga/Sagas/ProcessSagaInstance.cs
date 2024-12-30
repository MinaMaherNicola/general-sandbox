using MassTransit;

namespace Saga.Sagas;

public class ProcessSagaInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public required string CurrentState { get; set; }
    public bool Initiate { get; set; }
    public bool StepOne { get; set; }
    public bool StepTwo { get; set; }
}