using System;
using Project.Business.Managers;
using Project.DataLayer.Contracts;
using Project.DataLayer.DataAccessLayer;
using Project.DataLayer.Model;
using Project.InfraStructure.Contracts.Business;

namespace RawADODotNet.Web.Extensions.StartUp
{

    public static class ServiceCollectionExtension
    {

        public static IServiceCollection ConfigureConnectionString(this IServiceCollection services, ConfigurationManager configuration)
        {
            var appSettings = configuration.GetSection("ConnectionStrings");
            services.Configure<AppSettingsForConnectionString>(appSettings);
            return services;
        }

        public static IServiceCollection AddCMBuiltInDependency(this IServiceCollection services, IWebHostEnvironment environment, ConfigurationManager configuration)
        {
            // Add services to the container.
            services.AddControllersWithViews();
            return services;
        }

        public static IServiceCollection AddCMCustomDependency(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IDAL, DAL>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            return services;
        }
    }
}

