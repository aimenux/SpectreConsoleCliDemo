using Spectre.Console;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Math;

public sealed class SubCommand : AsyncCommand<MathSettings>
{
    public override Task<int> ExecuteAsync(CommandContext context, MathSettings settings)
    {
        checked
        {
            var first = settings.FirstNumber;
            var second = settings.SecondNumber;
            var sub = first - second;
            AnsiConsole.Write(new Markup($"[bold]Subtraction is[/] [green]{sub}[/]"));
        }

        return Task.FromResult(Settings.ExitCode.Ok);
    }
}