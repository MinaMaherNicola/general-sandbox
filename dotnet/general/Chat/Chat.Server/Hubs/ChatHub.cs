using Chat.Contract;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs;

public class ChatHub : Hub<IClient>
{
    public override async Task OnConnectedAsync()
    {
        await this.Clients.All.ReceiveMessageAsync($"New client with {this.Context.ConnectionId} connected to the chat!");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await this.Clients.All.ReceiveMessageAsync($"New client with {this.Context.ConnectionId} disconnected to the chat!");
    }

    public async Task SendMessageAsync(string message)
    {
        await this.Clients.All.ReceiveMessageAsync($"{this.Context.ConnectionId}: {message}");
    }
}