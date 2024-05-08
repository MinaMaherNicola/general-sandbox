using Chat.Contract;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs;

public class ChatHub : Hub<IClient>, IServerActions
{
    private static readonly Dictionary<string, string> GroupsConnection = new();

    public override async Task OnConnectedAsync()
    {
        ConnectionManager.ConnectedUsers[this.Context.ConnectionId] = this.Context.ConnectionId;
        await JoinRoom("default");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        ConnectionManager.ConnectedUsers.TryGetValue(this.Context.ConnectionId, out string? username);
        await this.Clients.AllExcept(this.Context.ConnectionId)
            .ReceiveMessageAsync($"Username {username ?? this.Context.ConnectionId} disconnected from the chat!");
        ConnectionManager.ConnectedUsers.Remove(this.Context.ConnectionId, out _);
        await LeaveRoom();
    }

    public async Task SendMessageAsync(string message)
    {
        ConnectionManager.ConnectedUsers.TryGetValue(this.Context.ConnectionId, out string? username);
        await this.Clients.OthersInGroup(GroupsConnection[this.Context.ConnectionId])
            .ReceiveMessageAsync($"{username ?? this.Context.ConnectionId}: {message}");
    }

    public async Task ChangeUsername(string username)
    {
        if (ConnectionManager.ConnectedUsers.ContainsKey(this.Context.ConnectionId) && username.Split(' ').Length > 1)
        {
            ConnectionManager.ConnectedUsers[this.Context.ConnectionId] = username.Split(' ')[1];
            await this.Clients.OthersInGroup(GroupsConnection[this.Context.ConnectionId]).ReceiveMessageAsync(
                ($"{this.Context.ConnectionId} changed username to {ConnectionManager.ConnectedUsers[this.Context.ConnectionId]}"));
        }
    }

    public async Task JoinRoom(string room)
    {
        GroupsConnection[this.Context.ConnectionId] = room;
        await this.Groups.AddToGroupAsync(this.Context.ConnectionId, room);

        ConnectionManager.ConnectedUsers.TryGetValue(this.Context.ConnectionId, out string? username);
        await SendMessageAsync($"{username ?? this.Context.ConnectionId} connected to the {room} room");
    }

    private async Task LeaveRoom()
    {
        if (GroupsConnection.TryGetValue(this.Context.ConnectionId, out string? value))
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId,
                value);
            GroupsConnection.Remove(this.Context.ConnectionId);
        }
    }
}