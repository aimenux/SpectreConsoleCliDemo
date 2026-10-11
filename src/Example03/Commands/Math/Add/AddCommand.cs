using Spectre.Console;
using Spectre.Console.Cli;

namespace Example03.Commands.Math.Add;

public sealed class AddCommand(IAnsiConsole console) : Command<AddSettings>
{
    public override int Execute(CommandContext context, AddSettings settings, CancellationToken cancellationToken)
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