using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReaderAPI.DataAccess.Context;
using ReaderAPI.DataAccess.Models;

namespace ReaderAPI.BackgroundServices.QueueListener;

public class UsersWriteListener(IServiceProvider serviceProvider) : BackgroundService
{
    private static readonly ConnectionFactory Factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", DispatchConsumersAsync = true };
    private static readonly IConnection Connection = Factory.CreateConnection();
    private readonly IModel _channel = Connection.CreateModel();

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Listening to queue");
        _channel.QueueDeclare("users_queue", true, false, false);
        _channel.QueueBind(queue: "users_queue", exchange: "cqrs_users", routingKey: "users");

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (_, ea) =>
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
                // Deserialize the message asynchronously
                User user = JsonSerializer.Deserialize<User>(Encoding.UTF8.GetString(ea.Body.ToArray()))!;

                Console.WriteLine("Listener fetched exchange user with id {0}", user.Id);

                // Asynchronously find and save the user
                var exists = await context.Users.FindAsync(user.Id);
                if (exists == null)
                {
                    await context.Users.AddAsync(user, stoppingToken);
                }
                else
                {
                    exists.Age = user.Age;
                    exists.Balance = user.Balance;
                    exists.Email = user.Email;
                    exists.IsActive = user.IsActive;
                    exists.Name = user.Name;
                }

                await context.SaveChangesAsync(stoppingToken);
                _channel.BasicAck(ea.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
            }
        };
        _channel.BasicConsume(queue: "users_queue", autoAck: false, consumer: consumer);

        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
        _channel?.Close();
        Connection?.Close();
    }
}