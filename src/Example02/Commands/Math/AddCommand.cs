using Spectre.Console;
using Spectre.Console.Cli;

namespace Example02.Commands.Math;

public sealed class AddCommand(IAnsiConsole console) : Command<MathSettings>
{
    public override int Execute(CommandContext context, MathSettings settings, CancellationToken cancellationToken)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sum = first + second;
            console.Write(new Markup($"[bold]Addition is[/] [green]{sum}[/]"));
        }

        return Settings.ExitCode.Ok;
    }
}