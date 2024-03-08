namespace CouchBaseLogging.ConsoleApp.CouchbaseClient.Contract
{
    public interface ICouchBaseClient
    {
        Task LogAsync(string message);
        ValueTask DisposeAsync();
    }
}
