using Microsoft.Extensions.DependencyInjection;
using WESTDemo.Domain.Services;
using WESTDemo.Domain.Interfaces;
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
            
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

            services.AddScoped<IUserTypeService, UserTypeService>();

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();

            services.AddScoped<IOrganisationService, OrganisationService>();

            services.AddScoped<ICentreRepository, CentreRepository>();

            services.AddScoped<ICentreService, CentreService>();
            
            return services;
        }
    }
}
