using Brokers.Portal.Modules.Products.Domain.Infrastructure;
using Brokers.Portal.Modules.Products.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Products
{
    public static class Extensions
    {
        public static IServiceCollection AddBrokerPortalProductServices(this IServiceCollection services, string connectionstring)
        {
            services.AddScoped<IProductServices>(s => new ProductServices(connectionstring));

            return services;
        }
    }
}
