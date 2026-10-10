using Spectre.Console.Cli;

namespace Example02.Core.Spectre;

public interface ISpectreConfigurator
{
    int Rank { get; }

    void Configure(IConfigurator configurator);
}