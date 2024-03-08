using Couchbase.KeyValue;
using Couchbase.Linq;

namespace CouchBasePractice.Extensions
{
    public static class BucketContextExtensions
    {
        public static async Task<ICouchbaseCollection> GetCollection<T>(this BucketContext context, string? scopeName = null)
        {
            IScope? scope = string.IsNullOrWhiteSpace(scopeName) ?
                            await context.Bucket.DefaultScopeAsync() :
                            await context.Bucket.ScopeAsync(scopeName);

            return await scope.CollectionAsync(typeof(T).Name);
        }
    }
}
