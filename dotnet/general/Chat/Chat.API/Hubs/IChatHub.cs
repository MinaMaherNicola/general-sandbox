
namespace Chat.API.Hubs
{
    public interface IChatHub
    {
        Task JoinRoom(string room, string username);
        Task LeaveRoom(string room, string username);
        Task SendMessage(string message, string username, string room);
    }
}