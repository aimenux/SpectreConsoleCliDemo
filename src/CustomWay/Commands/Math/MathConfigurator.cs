using CustomWay.Common.Spectre;
using Spectre.Console.Cli;

namespace CustomWay.Commands.Math
{
    public class MathConfigurator : ISpectreConfigurator
    {
        public int Rank => 1;

        public void Configure(IConfigurator config)
        {
            config.AddBranch("math", math =>
            {
                math
                    .AddCommand<AddCommand>("add")
                    .WithAlias("addition")
                    .WithDescription("Addition of two numbers")
                    .WithExample(new[] { "math", "add", "8", "5" });

                math
                    .AddCommand<SubCommand>("sub")
                    .WithAlias("subtraction")
                    .WithDescription("Subtraction of two numbers")
                    .WithExample(new[] { "math", "sub", "6", "2" });
            });
        }
    }
}
