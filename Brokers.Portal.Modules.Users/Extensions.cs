using Brokers.Portal.Modules.Users.Domain.Infrastructure;
using Brokers.Portal.Modules.Users.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Users
{
    public static class Extensions
    {
        public static IServiceCollection AddBrokerPortalUsersServices(this IServiceCollection services, string connectionstring)
        {
            services.AddScoped<IUserServices>(s => new UserServices(connectionstring));

            return services;
        }
    }
}
