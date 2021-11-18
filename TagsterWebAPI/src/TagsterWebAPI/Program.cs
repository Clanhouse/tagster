using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;
using Tagster.Logger;

namespace TagsterWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .UseLogging("TagsterWebAPI", typeof(Program).Assembly.GetName().Version.ToString())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((webHost, config) =>
                {
                    config.AddJsonFile(Path.Combine("Configuration", "appsettings.json"), false, true)
                    .AddJsonFile(Path.Combine("Configuration", $"appsettings.{webHost.HostingEnvironment.EnvironmentName}.json"), true, true)
                    .AddEnvironmentVariables();
                })
                .UseKestrel(opts =>
                {
                    opts.Listen(IPAddress.Any, 9000);
                })
                .UseStartup<Startup>();
            });
    }
}
