using Spectre.Console.Cli;

namespace BasicWay.Common.Spectre;

public sealed class SpectreCommandApp : ICommandApp
{
    private readonly CommandApp _commandApp;

    public SpectreCommandApp(ITypeRegistrar registrar)
    {
        _commandApp = new CommandApp(registrar);
    }

    public void Configure(Action<IConfigurator> configuration)
    {
        _commandApp.Configure(configuration);
    }

    public int Run(IEnumerable<string> args, CancellationToken cancellationToken)
    {
        return _commandApp.Run(args, cancellationToken);
    }

    public Task<int> RunAsync(IEnumerable<string> args, CancellationToken cancellationToken)
    {
        return _commandApp.RunAsync(args, cancellationToken);
    }
}