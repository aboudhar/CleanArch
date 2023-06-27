using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Persistence.DatabaseContext;
using BLCLicenseManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLCLicenseManagement.Persistence
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BLCDatabaseContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration.GetConnectionString("BLCDatabaseConnectionString"));
            });
            services.AddScoped(typeof(IGeneRecRepository<>), typeof(GeneRecRepository<>));
            services.AddScoped<ILicenseTypeRepository, LicenseTypeRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBLCApplicationRepository, BLCApplicationRepository>();
            services.AddScoped<IInstanceOfLicenseRepository, InstanceOfLicenseRepository>();
            return services;
        }
    }
}
