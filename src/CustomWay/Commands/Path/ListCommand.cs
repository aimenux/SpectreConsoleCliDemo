using Spectre.Console;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Path;

public sealed class ListCommand : AsyncCommand<PathSettings>
{
    public override Task<int> ExecuteAsync(CommandContext context, PathSettings settings)
    {
        var files = string.IsNullOrWhiteSpace(settings.FileExtension)
            ? Directory.GetFiles(settings.PathName)
            : Directory.GetFiles(settings.PathName, settings.FileExtension);

        foreach (var file in files)
        {
            var path = new TextPath(file)
                .RootColor(Color.Purple)
                .SeparatorColor(Color.Green)
                .StemColor(Color.Blue)
                .LeafColor(Color.Yellow);

            AnsiConsole.Write(path);
        }

        return Task.FromResult(Settings.ExitCode.Ok);
    }
}