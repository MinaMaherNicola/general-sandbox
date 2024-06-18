using Cashato.DB.Context;
using Cashato.NoSqlDB.Contracts;
using Cashato.NoSqlDB.Implementations;
using Cashato.NoSqlDB.Settings;
using Microsoft.EntityFrameworkCore;

namespace Cashato.Server.DependencyInjection
{
    public static class DataStoresDIExtensions
    {
        public static IServiceCollection AddDataStores(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CashatoContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.Configure<CouchBaseSettings>(configuration.GetSection("CouchBaseSettings"));
            services.AddSingleton<ICouchBaseClient, CouchBaseClient>();

            return services;
        }
    }
}
