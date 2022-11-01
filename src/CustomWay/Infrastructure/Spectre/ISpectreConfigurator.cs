using Spectre.Console.Cli;

namespace CustomWay.Infrastructure.Spectre;

public interface ISpectreConfigurator
{
    int Rank { get; }

    void Configure(IConfigurator configurator);
}