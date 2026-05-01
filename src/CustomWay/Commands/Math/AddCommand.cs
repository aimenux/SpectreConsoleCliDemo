using Spectre.Console;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Math;

public sealed class AddCommand : Command<MathSettings>
{
    protected override int Execute(CommandContext context, MathSettings settings, CancellationToken cancellationToken)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sum = first + second;
            AnsiConsole.Write(new Markup($"[bold]Addition is[/] [green]{sum}[/]"));
        }

        return Settings.ExitCode.Ok;
    }
}