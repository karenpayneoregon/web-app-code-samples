using System.Reflection;
using Microsoft.Extensions.Configuration;
#pragma warning disable CS8603 // Possible null reference return.

namespace SecretsLibrary;
public class SecretAppSettingReader
{
    public T ReadSection<T>(string sectionName)
    {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            //.AddUserSecrets<Program>()
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables();

        var configurationRoot = builder.Build();

        
        return configurationRoot.GetSection(sectionName).Get<T>();
    }
}