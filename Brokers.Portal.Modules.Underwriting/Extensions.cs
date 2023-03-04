using Brokers.Portal.Modules.Underwriting.Domain.Infrastructure;
using Brokers.Portal.Modules.Underwriting.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Brokers.Portal.Modules.Underwriting;


public static class Extensions
{
    public static IServiceCollection AddBrokerPortalUnderwritingServices(this IServiceCollection services, string connectionstring)
    {
        services.AddScoped<IUnderwritingServices>(s => new UnderwritingServices(connectionstring));

        return services;
    }
}
