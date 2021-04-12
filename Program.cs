using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Dapr.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DaprSecretsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    var daprClient = new DaprClientBuilder().Build();
                    config.AddDaprSecretStore("dapr-secretstore", daprClient);

                    // Uncomment the below if you want to use .NET Secret Manager instead of Dapr secrets when in local development
                    // if (hostContext.HostingEnvironment.IsDevelopment())
                    // {
                    //     config.AddUserSecrets<Program>();
                    // }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
