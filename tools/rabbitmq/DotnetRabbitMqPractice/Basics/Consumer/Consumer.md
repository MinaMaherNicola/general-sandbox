## MQ Consumer
You can see we create a basic queue using the `QueueDeclareAsync`.

We also allocate the `prefetchCount` equal to `1` in the `BasicQosAsync` so that we always assign one message to
a single consumer at a time. This is called **fair dispatch**, because we are dispatching the messages fairly.

Then we create a consumer using the `AsyncEventingBasicConsumer` class so that we could consume messages.

We consume messages using the event `ReceivedAsync`.

As you can see, we acknowledge the processing of every message using the `BasicAckAsync` function.
We have to give this function the `DeliveryTag` of the message we just processed.

But to make this enabled, we have to tell rabbitmq that we don't need the auto-acknowledgment enabled, so that
we could enable each message manually after consuming it.
We can do this by writing: `await channel.BasicConsumeAsync("hello", autoAck: false, consumer: consumer);`