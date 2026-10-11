using Spectre.Console;
using Spectre.Console.Cli;

namespace Example03.Commands.Math.Sub;

public sealed class SubCommand(IAnsiConsole console) : Command<SubSettings>
{
    public override int Execute(CommandContext context, SubSettings settings, CancellationToken cancellationToken)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sub = first - second;
            console.Write(new Markup($"[bold]Subtraction is[/] [green]{sub}[/]"));
        }

        return Settings.ExitCode.Ok;
    }
}