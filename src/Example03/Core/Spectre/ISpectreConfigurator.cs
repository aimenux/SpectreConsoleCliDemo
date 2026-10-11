using Spectre.Console.Cli;

namespace Example03.Core.Spectre;

public interface ISpectreConfigurator
{
    string Branch { get; }

    int Rank { get; }

    void Configure(IConfigurator<CommandSettings> branch);
}
