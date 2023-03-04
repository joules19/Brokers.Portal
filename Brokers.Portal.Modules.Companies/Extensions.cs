using Brokers.Portal.Modules.Company.Domain.Infrastructure;
using Brokers.Portal.Modules.Company.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Brokers.Portal.Modules.Company;


public static class Extensions
{
    public static IServiceCollection AddBrokerPortalCompanyServices(this IServiceCollection services, string connectionstring)
    {
        services.AddScoped<ICompanyServices>(s => new CompanyServices(connectionstring));

        return services;
    }
}
