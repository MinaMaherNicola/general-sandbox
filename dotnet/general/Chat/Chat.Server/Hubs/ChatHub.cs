using Chat.Contract;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs;

public class ChatHub : Hub<IClient>, IServerActions
{
    public override async Task OnConnectedAsync()
    {
        await this.Clients.AllExcept(this.Context.ConnectionId).ReceiveMessageAsync($"New client with {this.Context.ConnectionId} connected to the chat!");
        ConnectionManager.ConnectedUsers[this.Context.ConnectionId] = this.Context.ConnectionId;
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        ConnectionManager.ConnectedUsers.TryGetValue(this.Context.ConnectionId, out string? username);
        await this.Clients.AllExcept(this.Context.ConnectionId).ReceiveMessageAsync($"New client with {username ?? this.Context.ConnectionId} disconnected to the chat!");
        ConnectionManager.ConnectedUsers.Remove(this.Context.ConnectionId);
    }

    public async Task SendMessageAsync(string message)
    {
        ConnectionManager.ConnectedUsers.TryGetValue(this.Context.ConnectionId, out string? username);
        await this.Clients.AllExcept(this.Context.ConnectionId).ReceiveMessageAsync($"{username ?? this.Context.ConnectionId}: {message}");
    }

    public async Task ChangeUsername(string username)
    {
        if (ConnectionManager.ConnectedUsers.ContainsKey(this.Context.ConnectionId) && username.Split(' ').Length > 1)
        {
            ConnectionManager.ConnectedUsers[this.Context.ConnectionId] = username.Split(' ')[1];
            await this.Clients.All.ReceiveMessageAsync(($"{this.Context.ConnectionId} changed username to {ConnectionManager.ConnectedUsers[this.Context.ConnectionId]}"));
        }
    }
}