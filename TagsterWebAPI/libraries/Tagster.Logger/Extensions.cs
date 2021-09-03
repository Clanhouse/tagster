using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Sinks.Elasticsearch;
using Tagster.Logger.Options;

namespace Tagster.Logger
{
    public static class Extensions
    {
        private const string LoggerSectionName = "logger";

        public static IHostBuilder UseLogging(this IHostBuilder hostBuilder, string appName, string appVersion,
            Action<LoggerConfiguration> configure = null,
            string loggerSectionName = LoggerSectionName)
            => hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                if (string.IsNullOrWhiteSpace(loggerSectionName))
                {
                    loggerSectionName = LoggerSectionName;
                }

                LoggerOptions loggerOptions = new();
                context.Configuration.GetSection(loggerSectionName).Bind(loggerOptions);

                MapOptions(loggerOptions, appName, appVersion, loggerConfiguration, context.HostingEnvironment.EnvironmentName);
                configure?.Invoke(loggerConfiguration);
            });

        private static void MapOptions(LoggerOptions loggerOptions, string appName, string appVersion,
            LoggerConfiguration loggerConfiguration, string environmentName)
        {
            var level = GetLogEventLevel(loggerOptions.Level);

            loggerConfiguration.Enrich.FromLogContext()
                .MinimumLevel.Is(level)
                .Enrich.WithProperty("Environment", environmentName)
                .Enrich.WithProperty("Application", appName)
                .Enrich.WithProperty("Version", appVersion);

            foreach (var (key, value) in loggerOptions.Tags ?? new Dictionary<string, object>())
            {
                loggerConfiguration.Enrich.WithProperty(key, value);
            }

            foreach (var (key, value) in loggerOptions.MinimumLevelOverrides ?? new Dictionary<string, string>())
            {
                loggerConfiguration.MinimumLevel.Override(key, GetLogEventLevel(value));
            }

            loggerOptions.ExcludePaths?.ToList().ForEach(p => loggerConfiguration.Filter
                .ByExcluding(Matching.WithProperty<string>("RequestPath", n => n.EndsWith(p))));

            loggerOptions.ExcludeProperties?.ToList().ForEach(p => loggerConfiguration.Filter
                .ByExcluding(Matching.WithProperty(p)));

            Configure(loggerConfiguration, level, loggerOptions);
        }

        private static void Configure(LoggerConfiguration loggerConfiguration, LogEventLevel level,
            LoggerOptions options)
        {
            var consoleOptions = options.Console ?? new ConsoleOptions();
            var fileOptions = options.File ?? new FileOptions();
            var elkOptions = options.Elk ?? new ElkOptions();
            var seqOptions = options.Seq ?? new SeqOptions();

            if (consoleOptions.Enabled)
            {
                loggerConfiguration.WriteTo.Console();
            }

            if (fileOptions.Enabled)
            {
                var path = string.IsNullOrWhiteSpace(fileOptions.Path) ? "logs/logs.txt" : fileOptions.Path;
                if (!Enum.TryParse<RollingInterval>(fileOptions.Interval,
                    true, out var interval))
                {
                    interval = RollingInterval.Day;
                }

                loggerConfiguration.WriteTo.File(path, rollingInterval: interval);
            }

            if (elkOptions.Enabled)
            {
                loggerConfiguration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elkOptions.Url))
                    {
                        MinimumLogEventLevel = level,
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        IndexFormat = string.IsNullOrWhiteSpace(elkOptions.IndexFormat)
                        ? "logstash-{0:yyyy.MM.dd}"
                        : elkOptions.IndexFormat,
                        ModifyConnectionSettings = connectionConfiguration =>
                            elkOptions.BasicAuthEnabled
                                ? connectionConfiguration.BasicAuthentication(elkOptions.Username, elkOptions.Password)
                                : connectionConfiguration
                    });
            }

            if (seqOptions.Enabled)
            {
                loggerConfiguration.WriteTo.Seq(seqOptions.Url, apiKey: seqOptions.ApiKey);
            }
        }

        private static LogEventLevel GetLogEventLevel(string level)
            => Enum.TryParse<LogEventLevel>(level, true, out var logLevel)
                ? logLevel
                : LogEventLevel.Information;
    }
}