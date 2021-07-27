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
            .AddDataAccess("Data Source=DESKTOP-8O6TVH0\\SQLEXPRESS;Initial Catalog=Tagster;Integrated Security=True")
            .AddTransient<ITagsService, TagsService>();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app;
    }
}
