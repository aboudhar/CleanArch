using BLCLicenseManagement.Application.Contracts.Email;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Models.Email;
using BLCLicenseManagement.Infrastructure.EmailService;
using BLCLicenseManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLCLicenseManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}