using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockerCoffee.Shared.Contracts;
using DockerCoffee.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DockerCoffee.Shared
{
    public static class SharedServiceCollectionExtensions
    {
        public static void AddDockerCoffeeShared(this IServiceCollection services)
        {
            services.AddDbContext<CoffeeDbContext>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBeverageService, BeverageService>();
        }
    }
}
