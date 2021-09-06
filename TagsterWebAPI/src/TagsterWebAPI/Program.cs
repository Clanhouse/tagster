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
<<<<<<< HEAD
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
})
.UseLogging("TagsterWebAPI", typeof(Program).Assembly.GetName().Version.ToString());
        }
=======
            => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseLogging("TagsterWebAPI", typeof(Program).Assembly.GetName().Version.ToString());
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
    }
}
