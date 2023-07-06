using BLCLicenseManagement.API.Middleware;
using BLCLicenseManagement.Application;
using BLCLicenseManagement.Infrastructure;
using BLCLicenseManagement.Persistence;

namespace BLCLicenseManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.RegisterInfrastructureServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("all");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}