using CustomWay.Common.Spectre;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Path;

public sealed class PathConfigurator : ISpectreConfigurator
{
    public int Rank => 2;

    public void Configure(IConfigurator config)
    {
        config.AddBranch("path", path =>
        {
            path
                .AddCommand<ListCommand>("list")
                .WithDescription("List directory files")
                .WithExample("path", "list", "c:/", "-e", "*");

            path
                .AddCommand<CountCommand>("count")
                .WithDescription("Count directory files")
                .WithExample("path", "count", "c:/", "-e", "*");
        });
    }
}