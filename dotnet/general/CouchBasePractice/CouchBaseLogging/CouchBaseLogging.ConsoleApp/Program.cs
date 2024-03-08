using CouchBaseLogging.ConsoleApp.CouchbaseClient;
using CouchBaseLogging.ConsoleApp.CouchbaseClient.Contract;
using CouchBaseLogging.ConsoleApp.CouchBaseCustomLogger.Provider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CouchBaseLogging.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Set up dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get logger
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Use logger
            logger.LogInformation("7asal");
            logger.LogError("yom");
            logger.LogCritical("wara yom");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICouchBaseClient>(provider =>
                new CouchBaseClient("couchbase://localhost", "admin", "01206097754"));

            services.AddLogging(configure => configure.AddProvider(new CouchBaseLoggerProvider(
                services.BuildServiceProvider().GetRequiredService<ICouchBaseClient>())));
        }
    }
}
