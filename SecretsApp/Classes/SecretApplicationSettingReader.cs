using Microsoft.Extensions.Configuration;
using System.Reflection;
using SecretsApp.Models;

namespace SecretsApp.Classes;
public sealed class SecretApplicationSettingReader
{
    private static readonly Lazy<SecretApplicationSettingReader> _instance = new(() => new());

    public static SecretApplicationSettingReader Instance => _instance.Value;
    private readonly IConfigurationRoot _configuration;
    private readonly EnvironmentType _environment;

    private SecretApplicationSettingReader()
    {
        _environment = GetWorkingEnvironment();

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{_environment}.json", optional: true)
            .AddEnvironmentVariables();

        if (_environment == EnvironmentType.Development)
        {
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());
        }

        _configuration = builder.Build();
    }

    public T ReadSection<T>(string sectionName)
        => _configuration.GetSection(sectionName).Get<T>();

    public T ReadProperty<T>(string sectionName, string name)
        => _configuration.GetSection(sectionName).GetValue<T>(name);

    public string ConnectionString
        => ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

    public MailSettings MailSettings
        => ReadSection<MailSettings>(nameof(MailSettings));

    public EnvironmentType Environment => _environment;

    public static EnvironmentType GetWorkingEnvironment() =>
        System.Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") switch
        {
            "Development" => EnvironmentType.Development,
            "Production" => EnvironmentType.Production,
            _ => EnvironmentType.Development
        };

}

public class SecretApplicationSettingReader1
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