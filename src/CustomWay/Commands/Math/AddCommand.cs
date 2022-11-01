using Spectre.Console;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Math;

public class AddCommand : AsyncCommand<MathSettings>
{
    public override Task<int> ExecuteAsync(CommandContext context, MathSettings settings)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sum = first + second;
            AnsiConsole.Write(new Markup($"[bold]Addition is[/] [green]{sum}[/]"));
        }

        return Task.FromResult(Settings.ExitCode.Ok);
    }
}