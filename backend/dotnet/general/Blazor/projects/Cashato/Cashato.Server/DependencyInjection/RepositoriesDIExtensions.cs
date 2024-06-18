using Cashato.Business.Repositories.AccountsRepositories;

namespace Cashato.Server.DependencyInjection
{
    public static class RepositoriesDIExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
