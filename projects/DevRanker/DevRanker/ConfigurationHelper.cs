using Microsoft.Extensions.Configuration;
using System.IO;

public static class ConfigurationHelper
{
    private static IConfigurationRoot configuration;

    static ConfigurationHelper()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        configuration = builder.Build();
    }

    public static string GetConfigValue(string key)
    {
        return configuration[key];
    }
}