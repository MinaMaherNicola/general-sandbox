namespace RabbitMqMassTransit;

public static class Constants
{
    public const string ExchangeName = "my-direct-mass-transit";
    public const string ExchangeUrl = "rabbitmq://localhost/my-direct-mass-transit?type=direct&autodelete=true&durable=false";
}