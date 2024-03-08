using Couchbase.Linq;

namespace CouchBasePractice.CouchbaseContext
{
    public interface IContext
    {
        Task<BucketContext> GetContext();
    }
}
