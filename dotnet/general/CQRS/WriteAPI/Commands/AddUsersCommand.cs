using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using MediatR;
using WriteAPI.DataAccess.Collections;
using WriteAPI.DataAccess.Models;
using WriteAPI.Events;

namespace WriteAPI.Commands;

public record AddUsersCommand(List<User> Users) : IRequest;

internal class AddUsersCommandHandler(
    IUsersCollectionProvider provider,
    IMediator mediator,
    IClusterProvider clusterProvider) : IRequestHandler<AddUsersCommand>
{
    public async Task Handle(AddUsersCommand request, CancellationToken cancellationToken)
    {
        var cluster = await clusterProvider.GetClusterAsync();
        await cluster.WaitUntilReadyAsync(TimeSpan.FromSeconds(10));
        var collection = await provider.GetCollectionAsync();
        var upsertTasks = request.Users.Select(user => collection.UpsertAsync(user.Id.ToString(), user));
        await Task.WhenAll(upsertTasks);
        await mediator.Publish(new PublishToRabbitMqEvent(request.Users), cancellationToken);
    }
}