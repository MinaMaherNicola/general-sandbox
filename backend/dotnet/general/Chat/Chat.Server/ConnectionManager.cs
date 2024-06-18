using System.Collections.Concurrent;

namespace Chat.Server;

public static class ConnectionManager
{
    public static readonly Dictionary<string, string> ConnectedUsers = new();
}