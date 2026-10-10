using Example01.Commands.Math;
using Example01.Commands.Path;
using Example01.Core.Extensions;
using Example01.Core.Spectre;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Example01;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            return await CreateHostBuilder(args).RunSpectreCliAsync(args, config =>
            {
                    config.AddBranch("math", math =>
                    {
                        math
                            .AddCommand<AddCommand>("add")
                            .WithAlias("addition")
                            .WithDescription("Addition of two numbers")
                            .WithExample("math", "add", "8", "5");

                        math
                            .AddCommand<SubCommand>("sub")
                            .WithAlias("subtraction")
                            .WithDescription("Subtraction of two numbers")
                            .WithExample("math", "sub", "6", "2");
                    });
                    config.AddBranch("path", path =>
                    {
                        path
                            .AddCommand<ListCommand>("list")
                            .WithDescription("List directory files")
                            .WithExample("path", "list", "c:/", "-e", "*");

                        path
                            .AddCommand<CountCommand>("count")
                            .WithDescription("Count directory files")
                            .WithExample("path", "count", "c:/", "-e", "*");
                    });
            });
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