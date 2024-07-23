using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SecretsApp.Classes;
public class SecretApplicationSettingReader
{
    public T ReadSection<T>(string sectionName)
    {

        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .AddEnvironmentVariables();

        
        return builder.Build().GetSection(sectionName).Get<T>();
    }
}