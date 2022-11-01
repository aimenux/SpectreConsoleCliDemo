using CustomWay.Infrastructure.Spectre;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Path
{
    public class PathConfigurator : ISpectreConfigurator
    {
        public int Rank => 2;

        public void Configure(IConfigurator config)
        {
            config.AddBranch("path", path =>
            {
                path
                    .AddCommand<ListCommand>("list")
                    .WithDescription("List directory files")
                    .WithExample(new[] { "path", "list", "c:/", "-e", "*" });

                path
                    .AddCommand<CountCommand>("count")
                    .WithDescription("Count directory files")
                    .WithExample(new[] { "path", "count", "c:/", "-e", "*" });
            });
        }
    }
}
