namespace CustomWay;

public sealed class Settings
{
    public string ApplicationName { get; init; } = "spectre-console-cli";

    public string ApplicationVersion { get; init; } = "1.0";

    public static class ExitCode
    {
        public const int Ok = 0;
        public const int Ko = -1;
    }
}