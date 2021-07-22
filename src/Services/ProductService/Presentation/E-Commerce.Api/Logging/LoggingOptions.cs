using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace E_Commerce.Api.Logging
{
    public static class LoggingOptions
    {
        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-" +
                $"{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:dddd-yyyy-MM-HH-mm}"
            };
        }

        public static void ConfigureLogging()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var configuration = new ConfigurationBuilder()
               .SetBasePath(System.IO.Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env}.json", optional: true)
               .AddEnvironmentVariables()
               .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, env))
                .Enrich.WithProperty("Environment", env)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
