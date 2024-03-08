using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Couchbase.Linq;
using CouchBasePractice.ConcreteBucket;
using CouchBasePractice.CouchbaseContext;
using CouchBasePractice.Docuemnts;
using CouchBasePractice.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CouchBasePractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services
                .AddCouchbase(opt =>
                {
                    opt.ConnectionString = "couchbase://localhost";
                    opt.UserName = "admin";
                    opt.Password = "123456";
                    opt.AddLinq();
                })
                .AddCouchbaseBucket<ILearningBucket>("learning")
                .AddSingleton<IContext, Context>();
            services.AddLogging();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            ICluster cluster = await serviceProvider.GetRequiredService<IClusterProvider>().GetClusterAsync();
            await cluster.WaitUntilReadyAsync(TimeSpan.FromSeconds(10));

            BucketContext context = await serviceProvider.GetService<IContext>().GetContext();

            ICouchbaseCollection collection = await context.GetCollection<Plane>();

            Plane planeModel = new(Guid.NewGuid(), "F-22");
            await collection.UpsertAsync(planeModel.Id.ToString(), planeModel);
        }
    }
}
