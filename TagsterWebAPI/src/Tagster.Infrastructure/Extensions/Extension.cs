using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Application.Services;
using Tagster.DataAccess.Extensions;
using Tagster.Infrastructure.Services;

namespace Tagster.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services
            .AddDataAccess(@"Server=PAWEŁ-KOMPUTER\SQLEXPRESS;Database=Tagster;Trusted_Connection=True; ")
            .AddTransient<ITagService, TagsService>()
            .AddTransient<IProfileService, ProfileService>();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app;
    }
}
