using Microsoft.Extensions.Configuration;
using System.Reflection;
using SecretsApp.Models;

namespace SecretsApp.Classes;

public class SecretApplicationSettingReader
{
    public static T ReadSection<T>(string sectionName) 
        => ConfigurationBuilder<T>()
            .Build()
            .GetSection(sectionName).Get<T>();

    public static T ReadProperty<T>(string sectionName, string name) 
        => ConfigurationBuilder<T>()
            .Build()
            .GetSection(sectionName).GetValue<T>(name);

    private static IConfigurationBuilder ConfigurationBuilder<T>()
    {
        var environment = GetWorkingEnvironment();

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables();

        if (environment == EnvironmentType.Development)
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());

        return builder;
    }

    public static EnvironmentType GetWorkingEnvironment() =>
        Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") switch
        {
            "Development" => EnvironmentType.Development,
            "Production" => EnvironmentType.Production,
            _ => EnvironmentType.Development
        };

    public static string ConnectionString
     => ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));
    public static MailSettings MailSettings
        => ReadSection<MailSettings>(nameof(MailSettings));
}