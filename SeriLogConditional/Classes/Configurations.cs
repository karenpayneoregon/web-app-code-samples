namespace SeriLogConditional.Classes;

public class Configurations
{
    public static IConfigurationRoot GetLogConfigurationRoot()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("logsettings.json")
            .Build();
    }
}




