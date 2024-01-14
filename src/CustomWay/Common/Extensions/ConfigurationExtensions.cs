using Microsoft.Extensions.Configuration;

namespace CustomWay.Common.Extensions;

public static class ConfigurationExtensions
{
    public static void AddJsonFile(this IConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.SetBasePath(PathExtensions.GetDirectoryPath());
        var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
        configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        configurationBuilder.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
    }

    public static void AddUserSecrets(this IConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.AddUserSecrets(typeof(Program).Assembly);
    }
}