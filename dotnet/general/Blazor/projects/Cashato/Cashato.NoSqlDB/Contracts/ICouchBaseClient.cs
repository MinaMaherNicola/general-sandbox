namespace Cashato.NoSqlDB.Contracts
{
    public interface ICouchBaseClient
    {
        Task LogAsync(string message);
        ValueTask DisposeAsync();
    }
}
