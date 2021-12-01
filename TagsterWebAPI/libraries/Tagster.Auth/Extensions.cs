using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Auth.Factory;
using Tagster.Auth.Handlers;
using Tagster.Auth.Middleware;
using Tagster.Auth.Options;
using Tagster.Auth.Services;

namespace Tagster.Auth
{
    public static class Extensions
    {
        private const string SectionName = "jwt";

        public static IServiceCollection AddJwt(this IServiceCollection service, IConfiguration configuration,
            string sectionName = SectionName, Action<JwtBearerOptions> optionsFactory = null)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                sectionName = SectionName;
            }

            JwtOptions options = new();
            configuration.GetSection(sectionName).Bind(options);

            return service.AddJwt(options, optionsFactory);
        }

        private static IServiceCollection AddJwt(this IServiceCollection service, JwtOptions options,
            Action<JwtBearerOptions> optionsFactory = null)
        {
            service.AddTransient<IJwtHandler, JwtHandler>()
                .AddTransient<AccessTokenValidatorMiddleware>()
                .AddTransient<IPasswordService, PasswordService>()
                .AddTransient<IRng, Rng>()
                .AddSingleton<IPasswordHasher<IPasswordService>, PasswordHasher<IPasswordService>>()
                .AddSingleton<IAccessTokenService, InMemoryAccessTokenService>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var tokenValidationParameters = TokenValidationFactory.CreateParameters(options);
            tokenValidationParameters.AddIssuerSigningKey(options);
            tokenValidationParameters.AddAuthenticationType(options);
            tokenValidationParameters.AddNameClaimType(options);
            tokenValidationParameters.AddRoleClaimType(options);

            service.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
                {
                    option.Authority = options.Authority;
                    option.Audience = options.ValidAudience;
                    option.MetadataAddress = options.MetadataAddress;
                    option.SaveToken = options.SaveToken;
                    option.RefreshOnIssuerKeyNotFound = options.RefreshOnIssuerKeyNotFound;
                    option.RequireHttpsMetadata = options.RequireHttpsMetadata;
                    option.IncludeErrorDetails = options.IncludeErrorDetails;
                    option.TokenValidationParameters = tokenValidationParameters;
                    if (!string.IsNullOrWhiteSpace(options.Challenge))
                    {
                        option.Challenge = options.Challenge;
                    }

                    optionsFactory?.Invoke(option);
                });

            service.AddSingleton(options);
            service.AddSingleton(tokenValidationParameters);

            return service;
        }

        public static IApplicationBuilder UseAccessTokenValidator(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccessTokenValidatorMiddleware>();
        }
    }
}
