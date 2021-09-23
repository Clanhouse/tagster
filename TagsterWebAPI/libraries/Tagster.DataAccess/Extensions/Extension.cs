using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tagster.DataAccess.DBContexts;

namespace Tagster.DataAccess.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            return services
                       .AddDbContext<TagsterDbContext>(
                           opt => opt.UseSqlServer(connectionString,
                           b => b.MigrationsAssembly("Tagster.DataAccess")))
                       .AddScoped<TagsterDbContext>();
        }
    }
}
