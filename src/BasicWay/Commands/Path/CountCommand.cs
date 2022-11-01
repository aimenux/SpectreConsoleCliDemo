using Spectre.Console;
using Spectre.Console.Cli;

namespace BasicWay.Commands.Path;

public class CountCommand : AsyncCommand<PathSettings>
{
    public override Task<int> ExecuteAsync(CommandContext context, PathSettings settings)
    {
        var files = string.IsNullOrWhiteSpace(settings.FileExtension)
            ? Directory.GetFiles(settings.PathName)
            : Directory.GetFiles(settings.PathName, settings.FileExtension);

        AnsiConsole.Write(new Markup($"Found [bold][green]{files.Length}[/][/] file(s)"));

        return Task.FromResult(Settings.ExitCode.Ok);
    }
}