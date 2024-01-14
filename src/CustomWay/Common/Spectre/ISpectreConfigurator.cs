using Spectre.Console.Cli;

namespace CustomWay.Common.Spectre;

public interface ISpectreConfigurator
{
    int Rank { get; }

    void Configure(IConfigurator configurator);
}