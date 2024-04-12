using MediatR;
using RabbitMQ.Client;
using WriteAPI.DataAccess.Models;
using WriteAPI.Services;

namespace WriteAPI.Events;

public record PublishToRabbitMqEvent(List<User> Users) : INotification;

public class PublishToRabbitMqEventHandler(IRabbitMQService rabbitMqService) : INotificationHandler<PublishToRabbitMqEvent>
{
    public async Task Handle(PublishToRabbitMqEvent notification, CancellationToken cancellationToken)
    {
        await rabbitMqService.PublishUsersAsync(notification.Users);
    }
}