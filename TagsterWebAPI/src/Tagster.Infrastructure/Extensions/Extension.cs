using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tagster.DataAccess.DBContexts;

namespace Tagster.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddDbContext<TagsterDbContext>(options => options
            .UseSqlServer("Server=.;Database=tagster;Trusted_Connection=True; "))
            .AddScoped<ITagsterDbContext, TagsterDbContext>();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app;
    }
}
