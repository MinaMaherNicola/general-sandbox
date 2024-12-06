## Producer
We declare a simple queue using the `QueueDeclareAsync`, and then setup **fair dispatch** using the
`BasicQosAsync` and setting the `prefetchCount` of the messages to `1`. This means that each consumer will only
get a new message when it acknowledges the current one.

We can send messages to the queue using the `BasicPublishAsync`, but that message has to be an array of bytes.