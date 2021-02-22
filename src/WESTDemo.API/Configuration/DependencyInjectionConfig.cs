using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Services;
using WESTDemo.Infrastracture.Context;
using WESTDemo.Infrastracture.Repositories;

namespace WESTDemo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<UsersContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
