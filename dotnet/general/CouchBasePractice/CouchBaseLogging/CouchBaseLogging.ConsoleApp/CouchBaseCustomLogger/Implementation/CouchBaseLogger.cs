using CouchBaseLogging.ConsoleApp.CouchbaseClient.Contract;
using Microsoft.Extensions.Logging;

namespace CouchBaseLogging.ConsoleApp.CouchBaseCustomLogger.Implementation
{
    public class CouchBaseLogger : ILogger
    {
        private readonly ICouchBaseClient couchBaseClient;
        private readonly string categoryName;

        public CouchBaseLogger(ICouchBaseClient couchBaseClient, string categoryName)
        {
            this.couchBaseClient = couchBaseClient;
            this.categoryName = categoryName;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            string message = $"{DateTime.Now} | [{logLevel}] {((eventId.Id != 0) ? $"| {eventId.Id} - {eventId.Name}" : "")} | {categoryName} | {formatter(state, exception)}";



            Task.Run(async () =>
            {
                await couchBaseClient.LogAsync(message);
            })
            .ConfigureAwait(false);
        }
    }
}
