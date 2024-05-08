namespace Chat.Contract;

public interface IServerActions
{
    Task SendMessageAsync(string message);
    Task ChangeUsername(string username);
    Task JoinRoom(string room);
}