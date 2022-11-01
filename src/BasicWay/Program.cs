using BasicWay.Commands.Math;
using BasicWay.Commands.Path;
using BasicWay.Infrastructure.Host;
using BasicWay.Infrastructure.Spectre;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spectre.Console.Cli;

namespace BasicWay;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            using var host = CreateHostBuilder(args).Build();
            var settings = host.Services.GetRequiredService<IOptions<Settings>>().Value;
            var app = host.Services.GetRequiredService<ICommandApp>();
            app.Configure(config =>
            {
                config.ValidateExamples();
                config.PropagateExceptions();
                config.SetApplicationName(settings.ApplicationName);
                config.SetApplicationVersion(settings.ApplicationVersion);
                config.AddBranch("math", math =>
                {
                    math
                        .AddCommand<AddCommand>("add")
                        .WithAlias("addition")
                        .WithDescription("Addition of two numbers")
                        .WithExample(new[] { "math", "add", "8", "5" });

                    math
                        .AddCommand<SubCommand>("sub")
                        .WithAlias("subtraction")
                        .WithDescription("Subtraction of two numbers")
                        .WithExample(new[] { "math", "sub", "6", "2" });
                });
                config.AddBranch("path", path =>
                {
                    path
                        .AddCommand<ListCommand>("list")
                        .WithDescription("List directory files")
                        .WithExample(new[] { "path", "list", "c:/", "-e", "*" });

                    path
                        .AddCommand<CountCommand>("count")
                        .WithDescription("Count directory files")
                        .WithExample(new[] { "path", "count", "c:/", "-e", "*" });
                });
            });
            return await app.RunAsync(args);
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
                    scan.FromCallingAssembly()
                        .FromAssemblies(typeof(Program).Assembly)
                        .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime();
                });
                services.Configure<Settings>(hostingContext.Configuration.GetSection(nameof(Settings)));
                services.AddSingleton<ITypeResolver>(serviceProvider => new SpectreTypeResolver(serviceProvider));
                services.AddSingleton<ITypeRegistrar>(new SpectreTypeRegistrar(services));
                services.AddSingleton<ICommandApp, SpectreCommandApp>();
            })
            .AddSerilog();
}