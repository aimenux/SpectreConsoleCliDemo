using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Example01.Core.Spectre;

public static class SpectreExtensions
{
    public static async Task<int> RunSpectreCliAsync(this IHostBuilder hostBuilder, string[] args, Action<IConfigurator> configureCommands)
    {
        using var host = hostBuilder.Build();
        var app = host.Services.GetRequiredService<ICommandApp>();
        var settings = host.Services.GetRequiredService<IOptions<Settings>>().Value;
        app.Configure(config =>
        {
            config.ValidateExamples();
            config.PropagateExceptions();
            config.SetApplicationName(settings.ApplicationName);
            config.SetApplicationVersion(settings.ApplicationVersion);
            configureCommands(config);
        });
        return await app.RunAsync(args);
    }
    
    public static void RenderException<T>(this T exception) where T : Exception
    {
        const ExceptionFormats formats = ExceptionFormats.ShortenEverything;
        AnsiConsole.WriteLine();
        AnsiConsole.WriteException(exception, formats);
        AnsiConsole.WriteLine();
    }
}