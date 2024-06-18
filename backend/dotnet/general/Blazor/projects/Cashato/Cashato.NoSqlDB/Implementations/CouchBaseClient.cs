using Cashato.NoSqlDB.Contracts;
using Cashato.NoSqlDB.Settings;
using Couchbase;
using Couchbase.KeyValue;
using Microsoft.Extensions.Options;

namespace Cashato.NoSqlDB.Implementations
{
    public class CouchBaseClient : ICouchBaseClient, IAsyncDisposable
    {
        private readonly ICluster cluster;
        private readonly IBucket bucket;
        public CouchBaseClient(IOptions<CouchBaseSettings> settings)
        {
            cluster = Cluster.ConnectAsync(settings.Value.ServerHost, new ClusterOptions() { UserName = settings.Value.Username, Password = settings.Value.Password }).Result;
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
