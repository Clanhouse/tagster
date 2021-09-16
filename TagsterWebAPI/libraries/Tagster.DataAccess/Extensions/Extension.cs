using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tagster.DataAccess.DBContexts;

namespace Tagster.DataAccess.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
            => services.AddDbContext<TagsterDbContext>(options => options
            .UseSqlServer(connectionString))
            .AddScoped<ITagsterDbContext, TagsterDbContext>();
        
    }
}
