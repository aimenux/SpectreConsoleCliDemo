namespace CustomWay;

public class Settings
{
    public string ApplicationName { get; set; } = "spectre-cli";

    public string ApplicationVersion { get; set; } = "1.0";

    public static class ExitCode
    {
        public const int Ok = 0;
        public const int Ko = -1;
    }
}