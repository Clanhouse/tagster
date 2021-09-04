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
                sectionName = SectionName;

            RedisOptions options = new();
            configuration.GetSection(sectionName).Bind(options);
            return service.AddRedis(options);
        }

        public static IServiceCollection AddRedis(this IServiceCollection service,
            Func<IRedisOptionsBuilder, IRedisOptionsBuilder> buildOptions)
        {
            var options = buildOptions(new RedisOptionsBuilder()).Build();
            return service.AddRedis(options);
        }

        public static IServiceCollection AddRedis(this IServiceCollection service, RedisOptions options)
        {
            service.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = options.ConnectionString;
                o.InstanceName = options.Instance;
            });

            return service;
        }
    }
}