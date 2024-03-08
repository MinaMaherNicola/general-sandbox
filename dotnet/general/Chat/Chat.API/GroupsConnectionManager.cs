namespace Chat.API
{
    public class GroupsConnectionManager
    {
        public readonly HashSet<string> Groups = new();
        public readonly Dictionary<string, string> GroupsConnections = new();
    }
}
