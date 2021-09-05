using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
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
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
})
.UseLogging("TagsterWebAPI", typeof(Program).Assembly.GetName().Version.ToString());
        }
    }
}
