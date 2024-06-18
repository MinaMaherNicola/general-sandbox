using Cashato.Logging.Provider;

namespace Cashato.Server.DependencyInjection
{
    public static class CrossCuttingConcernsDIExtensions
    {
        public static IServiceCollection AddCrossCuttingConcernsPackages(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerProvider, CashatoLoggerProvider>();
            return services;
        }
    }
}
