using Example03.Core.Spectre;
using Spectre.Console.Cli;

namespace Example03.Commands.Math.Sub;

public sealed class SubConfigurator : ISpectreConfigurator
{
    public string Branch => "math";

    public int Rank => 2;

    public void Configure(IConfigurator<CommandSettings> branch)
    {
        branch
            .AddCommand<SubCommand>("sub")
            .WithAlias("subtraction")
            .WithDescription("Subtraction of two numbers")
            .WithExample("math", "sub", "6", "2");
    }
}
