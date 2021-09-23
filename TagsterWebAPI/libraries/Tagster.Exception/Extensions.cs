using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Exception.Factories;
using Tagster.Exception.Mappers;
using Tagster.Exception.Middlewares;
using Tagster.Exception.Models;

namespace Tagster.Exception
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandler<T>(this IServiceCollection services,
            JsonSerializerOptions serializerOptions = null)
            where T : class, IExceptionToResponseMapper
        {
            serializerOptions ??= new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return services
                .AddSingleton(serializerOptions)
                .AddTransient<ExceptionHandlerMiddleware>()
                .AddScoped<IExceptionToResponseMapper, T>()
                .AddScoped<IExceptionResponseFactory, ExceptionResponseFactory>();
        }

        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        private class EmptyExceptionToResponseMapper : IExceptionToResponseMapper
        {
            public Task<ExceptionResponse> Map(System.Exception exception)
            {
                return null;
            }
        }
    }
}
