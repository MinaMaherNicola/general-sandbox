using Cashato.Logging.Loggers;
using Cashato.NoSqlDB.Contracts;
using Microsoft.Extensions.Logging;

namespace Cashato.Logging.Provider
{
    public class CashatoLoggerProvider : ILoggerProvider
    {
        private readonly ICouchBaseClient couchBaseClient;

        public CashatoLoggerProvider(ICouchBaseClient couchBaseClient)
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
