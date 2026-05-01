using Spectre.Console;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Path;

public sealed class ListCommand : Command<PathSettings>
{
    protected override int Execute(CommandContext context, PathSettings settings, CancellationToken cancellationToken)
    {
        var files = string.IsNullOrWhiteSpace(settings.FileExtension)
            ? Directory.GetFiles(settings.PathName)
            : Directory.GetFiles(settings.PathName, settings.FileExtension);
        
        var count = files.Length;

        foreach (var file in files)
        {
            var path = new TextPath(file)
                .RootColor(Color.Purple)
                .SeparatorColor(Color.Green)
                .StemColor(Color.Blue)
                .LeafColor(Color.Yellow);
            
            AnsiConsole.Write(path);
            
            if (count-- > 1)
            {
                AnsiConsole.WriteLine();
            }
        }

        return Settings.ExitCode.Ok;
    }
}