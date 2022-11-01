using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;

namespace BasicWay.Infrastructure.Host;

public static class LoggingExtensions
{
    private const string DefaultCategoryName = "SpectreCliDemo";

    public static void AddDefaultLogger(this ILoggingBuilder loggingBuilder)
    {
        var services = loggingBuilder.Services;
        services.AddSingleton(serviceProvider =>
        {
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            return loggerFactory.CreateLogger(DefaultCategoryName);
        });
    }

    public static IHostBuilder AddSerilog(this IHostBuilder builder)
    {
        return builder.UseSerilog((hostingContext, _, loggerConfiguration) =>
        {
            SelfLog.Enable(Console.Error);

            var settingsFile = PathExtensions.GetSettingFilePath();
            if (File.Exists(settingsFile))
            {
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration);
            }
            else
            {
                var outputTemplate = GetOutputTemplate(hostingContext.Configuration);
                loggerConfiguration
                    .WriteTo.Console(outputTemplate: outputTemplate);
            }
        });
    }

    private static string GetOutputTemplate(IConfiguration configuration)
    {
        return configuration["Serilog:WriteTo:0:Args:outputTemplate"];
    }
}