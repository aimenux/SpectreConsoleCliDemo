using Spectre.Console;
using Spectre.Console.Cli;

namespace BasicWay.Commands.Path;

public sealed class CountCommand : Command<PathSettings>
{
    protected override int Execute(CommandContext context, PathSettings settings, CancellationToken cancellationToken)
    {
        var files = string.IsNullOrWhiteSpace(settings.FileExtension)
            ? Directory.GetFiles(settings.PathName)
            : Directory.GetFiles(settings.PathName, settings.FileExtension);

        AnsiConsole.Write(new Markup($"Found [bold][green]{files.Length}[/][/] file(s)"));

        return Settings.ExitCode.Ok;
    }
}