using Example03.Core.Spectre;
using Spectre.Console.Cli;

namespace Example03.Commands.Path.List;

public sealed class ListConfigurator : ISpectreConfigurator
{
    public string Branch => "path";

    public int Rank => 3;

    public void Configure(IConfigurator<CommandSettings> branch)
    {
        branch
            .AddCommand<ListCommand>("list")
            .WithDescription("List directory files")
            .WithExample("path", "list", "c:/", "-e", "*");
    }
}
