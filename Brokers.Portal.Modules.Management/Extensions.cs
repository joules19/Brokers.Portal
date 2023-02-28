using Brokers.Portal.Modules.Management.Domain.Infrastructure;
using Brokers.Portal.Modules.Management.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Brokers.Portal.Modules.Management;


public static class Extensions
{
    public static IServiceCollection AddBrokerPortalManagementServices(this IServiceCollection services, string connectionstring)
    {
        services.AddScoped<IManagementServices>(s => new ManagementServices(connectionstring));

        return services;
    }
}
