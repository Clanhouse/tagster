using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Application.Services;
using Tagster.Auth;
using Tagster.Domain.Repositories;
using Tagster.Exception;
using Tagster.Infrastructure.EF;
using Tagster.Infrastructure.EF.Repositories;
using Tagster.Infrastructure.Exceptions;
using Tagster.Infrastructure.Services;
using Tagster.Redis;

namespace Tagster.Infrastructure.Extensions;

public static class Extension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
        .AddJwt(configuration)
        .AddRedis(configuration)
        .AddErrorHandler<ExceptionToResponseMapper>()
        .AddExternalAuth(configuration)
        .AddDatabase(configuration)
        .AddScoped<ITagsRepository, TagsRepository>()
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
        .AddScoped<ICookieFactory, CookieFactory>()
        .AddScoped<IAdminService, AdminService>()
        .AddHostedService<DatabaseInitializer>();

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app) 
        => app.UseErrorHandler();
}
