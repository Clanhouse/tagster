using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Infrastructure.EF.Options;

namespace Tagster.Infrastructure.EF
{
    internal static class Extension
    {
        public static IServiceCollection UseDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOption = configuration.GetSection(DatabaseOption.Name).Get<DatabaseOption>();

            return services
                .AddDbContext<TagsterDbContext>(
                opt => opt.Configure(databaseOption));
        }


        private static DbContextOptionsBuilder Configure(this DbContextOptionsBuilder builder, DatabaseOption options)
        {
            switch (options.Type)
            {
                case DatabaseType.SQLServer:
                    builder.UseSqlServer(options.ConectionString);
                    break;
                case DatabaseType.PostgreSQL:
                    builder.UseNpgsql(options.ConectionString);
                    break;
                default:
                    break;
            }

            return builder;
        }
    }
}
