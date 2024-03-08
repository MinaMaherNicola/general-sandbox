using CouchBaseLogging.ConsoleApp.CouchbaseClient.Contract;
using CouchBaseLogging.ConsoleApp.CouchBaseCustomLogger.Implementation;
using Microsoft.Extensions.Logging;

namespace CouchBaseLogging.ConsoleApp.CouchBaseCustomLogger.Provider
{
    internal class CouchBaseLoggerProvider : ILoggerProvider
    {
        private readonly ICouchBaseClient couchBaseClient;

        public CouchBaseLoggerProvider(ICouchBaseClient couchBaseClient)
        {
            this.couchBaseClient = couchBaseClient;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CouchBaseLogger(couchBaseClient, categoryName);
        }

        public void Dispose()
        {
            couchBaseClient.DisposeAsync().ConfigureAwait(false);
        }
    }
}
