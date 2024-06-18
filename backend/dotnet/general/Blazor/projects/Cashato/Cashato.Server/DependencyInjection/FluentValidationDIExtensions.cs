using Cashato.Business.Dtos.Accounts;
using Cashato.Business.Validators.Accounts;
using FluentValidation;

namespace Cashato.Server.DependencyInjection
{
    public static class FluentValidationDIExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddAccountRequest>, CreateAccountValidator>();
            return services;
        }
    }
}
