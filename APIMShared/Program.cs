using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace APIMShared
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
                {
                    var configuration = configurationBuilder.Build();

                    var keyVaultVariablesUrl = configuration["KeyVaultVariablesUrl"];
                    var secretClient = new SecretClient(new Uri(keyVaultVariablesUrl), new DefaultAzureCredential());

                    configurationBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}