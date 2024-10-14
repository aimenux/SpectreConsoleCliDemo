using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace BasicWay.Commands.Path;

public sealed class PathSettings : CommandSettings
{
    [CommandArgument(0, "<PATH_NAME>")]
    public string PathName { get; set; }

    [CommandOption("-e|--extension")]
    [Description("Filter on file extension.")]
    [DefaultValue("*")]
    public string FileExtension { get; set; }

    public override ValidationResult Validate()
    {
        return !Directory.Exists(PathName)
            ? ValidationResult.Error("PATH_NAME does not exist")
            : ValidationResult.Success();
    }
}