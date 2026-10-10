using Spectre.Console;
using Spectre.Console.Cli;

namespace Example01.Commands.Path;

public sealed class CountCommand(IAnsiConsole console) : Command<PathSettings>
{
    public override int Execute(CommandContext context, PathSettings settings, CancellationToken cancellationToken)
    {
        var files = string.IsNullOrWhiteSpace(settings.FileExtension)
            ? Directory.GetFiles(settings.PathName)
            : Directory.GetFiles(settings.PathName, settings.FileExtension);

        console.Write(new Markup($"Found [bold][green]{files.Length}[/][/] file(s)"));

        return Settings.ExitCode.Ok;
    }
}