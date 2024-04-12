using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using WriteAPI.DataAccess.Models;

namespace WriteAPI.Services;

public class RabbitMQService : IRabbitMQService
{
    private static readonly ConnectionFactory Factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
    public async Task PublishUsersAsync(List<User> users)
    {
        using var connection = Factory.CreateConnection();
        using var channel = connection.CreateModel();
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        channel.ExchangeDeclare(exchange: "cqrs_users", ExchangeType.Direct, true, false);

        foreach (var user in users)
        {
            channel.BasicPublish(exchange: "cqrs_users",
                routingKey: "users",
                basicProperties: properties,
                body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(user)));
        }

        await Task.CompletedTask;
    }
}