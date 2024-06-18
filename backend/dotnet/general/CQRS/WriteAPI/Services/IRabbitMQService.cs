using WriteAPI.DataAccess.Models;

namespace WriteAPI.Services;

public interface IRabbitMQService
{
    Task PublishUsersAsync(List<User> users);
}