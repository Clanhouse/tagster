using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Tagster.Swagger.Builders;
using Tagster.Swagger.Options;

namespace Tagster.Swagger
{
    public static class Extensions
    {
        private const string SectionName = "swagger";

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection service,
            IConfiguration configuration, string xmlPath = "", string sectionName = SectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                sectionName = SectionName;
            }

            SwaggerOptions options = new();
            configuration.GetSection(sectionName).Bind(options);
            return service.AddSwaggerDocs(options, xmlPath);
        }

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection service,
            Func<ISwaggerOptionsBuilder, ISwaggerOptionsBuilder> buildOptions, string xmlPath = "")
        {
            var options = buildOptions(new SwaggerOptionsBuilder()).Build();
            return service.AddSwaggerDocs(options, xmlPath);
        }

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection service,
            SwaggerOptions options, string xmlPath = "")
        {
            service.AddSingleton(options);

            if (!options.Enabled)
            {
                return service;
            }

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options.Name,
                    new OpenApiInfo
                    {
                        Title = options.Title,
                        Version = options.Version,
                        Contact = new OpenApiContact
                        {
                            Name = options.ContactName,
                            Email = options.ContactEmail
                        }
                    });

                if (!string.IsNullOrWhiteSpace(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }

                if (options.IncludeSecurity)
                {
                    c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. "
                        + "Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                }
            });

            return service;
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetService<SwaggerOptions>();
            if (!options.Enabled)
            {
                return app;
            }

            var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix)
                ? "swagger"
                : options.RoutePrefix;

            return app
                .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json")
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
                    c.RoutePrefix = routePrefix;
                    c.DocExpansion(DocExpansion.None);
                });
        }
    }
}