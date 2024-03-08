using Microsoft.AspNetCore.SignalR;

namespace Chat.API.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly GroupsConnectionManager groupsManager;

        public ChatHub(GroupsConnectionManager groupNames)
        {
            this.groupsManager = groupNames;
        }

        public async Task JoinRoom(string room, string username)
        {
            if (!groupsManager.Groups.Contains(room))
            {
                groupsManager.Groups.Add(room);
            }

            groupsManager.GroupsConnections[Context.ConnectionId] = room;
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendMessage($"{username} has joined the chat", username, room);
        }

        public async Task LeaveRoom(string room, string username)
        {
            if (!groupsManager.Groups.Contains(room))
            {
                throw new ArgumentException("Room doesn't exist");
            }

            if (groupsManager.GroupsConnections.TryGetValue(Context.ConnectionId, out var userRoom) && userRoom == room)
            {
                groupsManager.GroupsConnections.Remove(Context.ConnectionId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
                await Clients.Group(room).SendMessage($"{username} has left the chat", username, room);
                await Clients.Client(Context.ConnectionId).SendMessage("You have left the chat", username, room);
            }
            else
            {
                throw new InvalidOperationException("User is not in the specified room");
            }
        }

        public async Task SendMessage(string message, string username, string room)
        {
            if (!groupsManager.Groups.Contains(room))
            {
                throw new ArgumentException("Room doesn't exist");
            }

            if (groupsManager.GroupsConnections.TryGetValue(Context.ConnectionId, out var userRoom) && userRoom == room)
            {
                await Clients.Group(room).SendMessage($"{username}: {message}", username, room);
            }
            else
            {
                throw new InvalidOperationException("User is not in the specified room");
            }
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (groupsManager.GroupsConnections.TryGetValue(Context.ConnectionId, out var room))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
                groupsManager.GroupsConnections.Remove(Context.ConnectionId);
            }

            Console.WriteLine($"Disconnected {exception?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
