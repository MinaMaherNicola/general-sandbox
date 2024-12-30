using MassTransit;
using Saga.Messages;

namespace Saga.Sagas;

public class ProcessSagaStateMachine : MassTransitStateMachine<ProcessSagaInstance>
{
    public State InitiateProcess { get; private set; } = null!;
    public State StepOne { get; private set; } = null!;
    public State StepTwo { get; private set; } = null!;

    public Event<InitiateProcess> InitiateProcessEvent { get; private set; } = null!;
    public Event<StepOne> StepOneEvent { get; private set; } = null!;
    public Event<StepTwo> StepTwoEvent { get; private set; } = null!;

    public ProcessSagaStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => InitiateProcessEvent, x => x.CorrelateById(context => context.Message.CorrelationId));
        Event(() => StepOneEvent, x => x.CorrelateById(context => context.Message.CorrelationId));
        Event(() => StepTwoEvent, x => x.CorrelateById(context => context.Message.CorrelationId));

        Initially(When(InitiateProcessEvent)
            .Then(ctx =>
            {
                Console.WriteLine($"-> Saga Initiate Process: {ctx.Message.CorrelationId}");
                ctx.Saga.Initiate = true;
            })
            .TransitionTo(StepOne)
            .PublishAsync(ctx => ctx.Init<StepOne>(new StepOne()
            {
                CorrelationId = ctx.Message.CorrelationId
            }))
        );

        During(StepOne,
            When(StepOneEvent)
                .Then(ctx =>
                {
                    Console.WriteLine($"-> Saga step one: {ctx.Message.StepOneMessage}");
                    ctx.Saga.StepOne = true;
                })
                .TransitionTo(StepTwo)
        );

        During(StepTwo,
            When(StepTwoEvent)
                .Then(ctx =>
                {
                    Console.WriteLine($"-> Saga step two: {ctx.Message.StepTwoMessage}");
                    ctx.Saga.StepTwo = true;
                })
                .Finalize()
        );
        
        SetCompletedWhenFinalized();
    }
}