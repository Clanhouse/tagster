using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Application.Services;
using Tagster.Auth;
using Tagster.DataAccess.Extensions;
using Tagster.Exception;
using Tagster.Infrastructure.Exceptions;
using Tagster.Infrastructure.Services;
using Tagster.Redis;

namespace Tagster.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddJwt(configuration)
            .AddRedis(configuration)
            .AddErrorHandler<ExceptionToResponseMapper>()
            .AddDataAccess(configuration.GetConnectionString("DefaultConnection"))
            .AddTransient<ITagsService, TagsService>()
            .AddTransient<ICookieFactory, CookieFactory>()
            .AddTransient<IAdminService, AdminService>();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app.UseErrorHandler();
        }
    }
}
