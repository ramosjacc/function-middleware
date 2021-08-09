using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleHttpFunction.Middleware;
using System.Threading.Tasks;

namespace SimpleHttpFunction
{
    class Program
    {
        static Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddCommandLine(args);
                })
                .ConfigureFunctionsWorkerDefaults(builder => {
                    builder.UseMiddleware<TenantMiddleware>();
                })
                .ConfigureServices(services =>
                {
                    
                    // Add Logging
                    services.AddLogging(logging => {
                        logging.AddDebug();
                    });

                    // Add HttpClient
                    services.AddHttpClient();
                })
                .Build();

            return host.RunAsync();
        }

    }
}
