using Spectre.Console;
using Spectre.Console.Cli;

namespace Example02.Commands.Math;

public sealed class SubCommand(IAnsiConsole console) : Command<MathSettings>
{
    public override int Execute(CommandContext context, MathSettings settings, CancellationToken cancellationToken)
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