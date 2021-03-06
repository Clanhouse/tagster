using Microsoft.Extensions.DependencyInjection;
using Tagster.Application.Services;
using Tagster.Auth.Services;

namespace Tagster.Application.Extensions;

public static class Extension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
        .AddScoped<IIdentityService, IdentityService>()
        .AddScoped<IJwtProvider, JwtProvider>()
        .AddScoped<IRefreshTokenService, RefreshTokenService>();
}
