using Spectre.Console;
using Spectre.Console.Cli;

namespace BasicWay.Commands.Math;

public class MathSettings : CommandSettings
{
    [CommandArgument(0, "<FIRST_NUMBER>")]
    public int FirstNumber { get; set; }

    [CommandArgument(1, "<SECOND_NUMBER>")]
    public int SecondNumber { get; set; }

    public override ValidationResult Validate()
    {
        if (FirstNumber <= 0)
        {
            return ValidationResult.Error("FIRST_NUMBER must be greater than 0");
        }

        if (SecondNumber <= 0)
        {
            return ValidationResult.Error("SECOND_NUMBER must be greater than 0");
        }

        return ValidationResult.Success();
    }
}