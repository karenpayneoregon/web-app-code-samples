namespace Sessions1.Classes;

public class Utilities
{
    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    /// <summary>
    /// Get session timeout from appsettings.json
    /// </summary>
    /// <returns></returns>
    public static int SessionTimeout()
    {
        return Convert.ToInt32(ConfigurationRoot().GetSection(ApplicationConfigurations.Path).Value);
    }
}