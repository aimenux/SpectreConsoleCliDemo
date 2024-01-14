using Spectre.Console.Cli;

namespace BasicWay.Common.Spectre
{
    public class SpectreCommandApp : ICommandApp
    {
        private readonly ICommandApp _commandApp;

        public SpectreCommandApp(ITypeRegistrar registrar)
        {
            _commandApp = new CommandApp(registrar);
        }

        public void Configure(Action<IConfigurator> configuration)
        {
            _commandApp.Configure(configuration);
        }

        public int Run(IEnumerable<string> args)
        {
            return _commandApp.Run(args);
        }

        public Task<int> RunAsync(IEnumerable<string> args)
        {
            return _commandApp.RunAsync(args);
        }
    }
}
