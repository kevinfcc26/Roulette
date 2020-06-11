using Microsoft.Extensions.DependencyInjection;
using RouletteApi.Models;
using RouletteApi.Repositories;
using RouletteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            return services;
        }
        public static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<RouletteService>();
            return services;
        }
        public static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<RedisRepository>();

            return services;
        }
    }
}