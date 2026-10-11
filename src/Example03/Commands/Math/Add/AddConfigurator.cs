using Example03.Core.Spectre;
using Spectre.Console.Cli;

namespace Example03.Commands.Math.Add;

public sealed class AddConfigurator : ISpectreConfigurator
{
    public string Branch => "math";

    public int Rank => 1;

    public void Configure(IConfigurator<CommandSettings> branch)
    {
        branch
            .AddCommand<AddCommand>("add")
            .WithAlias("addition")
            .WithDescription("Addition of two numbers")
            .WithExample("math", "add", "8", "5");
    }
}
