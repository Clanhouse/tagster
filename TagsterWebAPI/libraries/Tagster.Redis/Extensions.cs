using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagster.Redis.Builders;

namespace Tagster.Redis
{
    public static class Extensions
    {
        private const string SectionName = "redis";

        public static IServiceCollection AddRedis(this IServiceCollection service, IConfiguration configuration,
            string sectionName = SectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                sectionName = SectionName;
            }

            RedisOptions options = new();
            configuration.GetSection(sectionName).Bind(options);
            return service.AddRedis(options);
        }

        public static IServiceCollection AddRedis(this IServiceCollection service,
            Func<IRedisOptionsBuilder, IRedisOptionsBuilder> buildOptions)
        {
            return service.AddRedis(buildOptions(new RedisOptionsBuilder()).Build());
        }

        public static IServiceCollection AddRedis(this IServiceCollection service, RedisOptions options)
        {
            return service.AddStackExchangeRedisCache(o =>
                        {
                            o.Configuration = options.ConnectionString;
                            o.InstanceName = options.Instance;
                        });
        }
    }
}