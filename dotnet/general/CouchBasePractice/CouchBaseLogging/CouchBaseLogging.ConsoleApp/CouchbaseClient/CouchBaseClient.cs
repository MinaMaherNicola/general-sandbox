using Couchbase;
using Couchbase.KeyValue;
using CouchBaseLogging.ConsoleApp.CouchbaseClient.Contract;

namespace CouchBaseLogging.ConsoleApp.CouchbaseClient
{
    internal class CouchBaseClient : ICouchBaseClient, IAsyncDisposable
    {
        private readonly ICluster cluster;
        private readonly IBucket bucket;
        public CouchBaseClient(string serverHost, string username, string password)
        {
            cluster = Cluster.ConnectAsync(serverHost, new ClusterOptions() { UserName = username, Password = password }).Result;
            cluster.WaitUntilReadyAsync(TimeSpan.FromSeconds(30)).Wait();
            bucket = cluster.BucketAsync("cashatologs").Result;
        }
        public async ValueTask DisposeAsync()
        {
            await bucket.DisposeAsync();
            await cluster.DisposeAsync();
        }

        public async Task LogAsync(string message)
        {
            ICouchbaseCollection collection = await bucket.DefaultCollectionAsync();
            await collection.InsertAsync(Guid.NewGuid().ToString(), message);
        }
    }
}
