using Chat.Contract;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Client;

public class Client : IClient
{
    private readonly HubConnection _connection;

    public Client()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:8080/chat")
            .WithAutomaticReconnect()
            .Build();
        _connection.On<string>(nameof(IClient.ReceiveMessageAsync), async message => await ReceiveMessageAsync(message));
    }

    public async Task StartAsync()
    {
        await _connection.StartAsync();
    }

    public async Task ReceiveMessageAsync(string message)
    {
        Console.WriteLine(message);
        await Task.CompletedTask;
    }

    public async Task SendMessageAsync(string message)
    {
        await _connection.InvokeAsync(nameof(IClient.SendMessageAsync), message);
    }

    public async Task<string?> GetConnectionId()
    {
        return await Task.FromResult(_connection.ConnectionId);
    }

    public async Task DisposeAsync()
    {
        await _connection.StopAsync();
        await _connection.DisposeAsync();
    }
}