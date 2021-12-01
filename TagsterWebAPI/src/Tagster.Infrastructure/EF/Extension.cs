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
                opt => opt.UseNpgsql(databaseOption.ConectionString));
        }
    }
}
