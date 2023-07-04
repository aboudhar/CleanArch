using BLCLicense_Management.BlazorUI.Contracts;
using BLCLicense_Management.BlazorUI.Services;
using BLCLicense_Management.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

namespace BLCLicense_Management.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7112"));
            builder.Services.AddScoped<ILicenseTypeService, LicenseTypeService>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            await builder.Build().RunAsync();
        }
    }
}