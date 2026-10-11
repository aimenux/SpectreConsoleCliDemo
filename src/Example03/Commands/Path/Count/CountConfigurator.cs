using Example03.Core.Spectre;
using Spectre.Console.Cli;

namespace Example03.Commands.Path.Count;

public sealed class CountConfigurator : ISpectreConfigurator
{
    public string Branch => "path";

    public int Rank => 4;

    public void Configure(IConfigurator<CommandSettings> branch)
    {
        branch
            .AddCommand<CountCommand>("count")
            .WithDescription("Count directory files")
            .WithExample("path", "count", "c:/", "-e", "*");
    }
}
