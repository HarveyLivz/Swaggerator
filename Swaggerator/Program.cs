using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Swaggerator.Services;
using Swaggerator.Shared;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Swaggerator;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Add HttpClient
        builder.Services.AddScoped(sp => new HttpClient 
        { 
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
        });

        // Configuration
        builder.Services.AddSingleton<IConfiguration>(sp =>
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(builder.HostEnvironment.BaseAddress)
                .AddJsonFile("wwwroot/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config;
        });

        // YAML Deserialization Services
        builder.Services.AddSingleton<IDeserializer>(_ => new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build());

        // Custom YAML Service
        builder.Services.AddScoped<IYamlService, YamlService>();

        await builder.Build().RunAsync();
    }
}