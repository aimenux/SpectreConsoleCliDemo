using Spectre.Console;
using Spectre.Console.Cli;

namespace BasicWay.Commands.Math;

public sealed class SubCommand : Command<MathSettings>
{
    protected override int Execute(CommandContext context, MathSettings settings, CancellationToken cancellationToken)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sub = first - second;
            AnsiConsole.Write(new Markup($"[bold]Subtraction is[/] [green]{sub}[/]"));
        }

        return Settings.ExitCode.Ok;
    }
}