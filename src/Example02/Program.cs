using Example02.Core.Extensions;
using Example02.Core.Spectre;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Example02;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            return await CreateHostBuilder(args).RunSpectreCliAsync(args);
        }
        catch (Exception ex)
        {
            ex.RenderException();
            return Settings.ExitCode.Ko;
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile();
                config.AddUserSecrets();
                config.AddEnvironmentVariables();
                config.AddCommandLine(args);
            })
            .ConfigureLogging((_, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddDefaultLogger();
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.Scan(scan =>
                {
                    scan.FromAssemblies(typeof(Program).Assembly)
                        .AddClasses()
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime();
                });
                services.Configure<Settings>(hostingContext.Configuration.GetSection(nameof(Settings)));
                services.AddSingleton(AnsiConsole.Console);
                services.AddSingleton<ITypeResolver>(serviceProvider => new SpectreTypeResolver(serviceProvider));
                services.AddSingleton<ITypeRegistrar>(new SpectreTypeRegistrar(services));
            })
            .AddSerilog();
}