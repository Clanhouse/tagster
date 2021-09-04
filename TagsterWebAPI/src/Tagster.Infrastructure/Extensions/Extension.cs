using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Application.Services;
using Tagster.Auth;
using Tagster.DataAccess.Extensions;
using Tagster.Infrastructure.Services;

namespace Tagster.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddJwt(configuration)
            .AddDataAccess(configuration.GetConnectionString("DefaultConnection"))
            .AddTransient<ITagsService, TagsService>();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app;
    }
}
