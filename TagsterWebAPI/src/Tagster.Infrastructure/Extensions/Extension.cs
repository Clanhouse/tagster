using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tagster.DataAccess.Extensions;

namespace Tagster.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddDataAccess("Server=.;Database=tagster;Trusted_Connection=True; ");

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app;
    }
}
