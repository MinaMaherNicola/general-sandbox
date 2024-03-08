using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using CouchBasePractice.ConcreteBucket;

namespace CouchBasePractice.CouchbaseContext
{
    public class Context : IContext
    {
        private BucketContext context;
        private readonly IClusterProvider clusterProvider;
        private readonly ILearningBucket learningBucket;

        public Context(IClusterProvider clusterProvider, ILearningBucket learningBucket)
        {
            this.clusterProvider = clusterProvider;
            this.learningBucket = learningBucket;
        }

        private async Task InitializeAsync()
        {
            ICluster cluster = await clusterProvider.GetClusterAsync();
            await cluster.WaitUntilReadyAsync(TimeSpan.FromSeconds(10));
            context = new BucketContext(await learningBucket.GetBucketAsync());
        }

        public async Task<BucketContext> GetContext()
        {
            await InitializeAsync();
            if (context == null)
            {
                throw new InvalidOperationException("Context was not initialized successfully");
            }
            return context;
        }
    }
}
