namespace Chat.Contract;

public interface IClient
{
    Task ReceiveMessageAsync(string message);
}