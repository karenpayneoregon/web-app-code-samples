using Microsoft.Extensions.Configuration;
using Revenue.Configuration.Core1.Data;
using Revenue.Configuration.Core1.Models;
// ReSharper disable PossibleInvalidOperationException

namespace Revenue.Configuration.Core1;

/// <summary>
/// Responsible for obtaining settings from a configuration file using a thread safe singleton pattern.
/// 
/// There are options to read from an environment variable or a json file which there needs to be a discussion
/// on how the team wants to use.
///
/// Some settings may not be needed along with more settings to be added as needed.
/// </summary>
public class SettingsManager
{
    private static readonly Lazy<SettingsManager> Lazy = new(() => new SettingsManager());

    public static SettingsManager Configuration => Lazy.Value;

    /// <summary>
    /// Indicates the application from dbo.Applications
    /// </summary>
    public int ApplicationIdentifier => 2;
    public AzureSettings AzureSettings { get; set; }
    public WebPageSettings WebPageSettings { get; set; }
    public MailSettings MailSettings { get; set; }
    public GeneralSettings GeneralSettings { get; set; }
    public bool ClientValidationEnabled { get; set; }
    public bool UnobtrusiveJavaScriptEnabled { get; set; }
    public string ServicePath { get; set; }
    public string ErrorMessageFromAddress { get; set; }
    /// <summary>
    /// Main connection for this application
    /// </summary>
    public string MainDatabaseConnection { get; set; }
    // optional: The idea is to show multiple connections are possible
    public string OtherDatabaseConnection { get; set; }

    private static IConfigurationRoot Builder()
    {
        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", true);

        var configuration = builder.Build();
        return configuration;
    }
    public SettingsManager()
    {
        Load();
    }

    private void Load()
    {
        using var context = new Context();
        WebPageSettings = context.WebPageSettings.FirstOrDefault(x => x.Identifier == ApplicationIdentifier);
        AzureSettings = context.AzureSettings.FirstOrDefault(x => x.Identifier == ApplicationIdentifier);
        MailSettings = context.MailSettings.FirstOrDefault(x => x.Identifier == ApplicationIdentifier);
        var generalSettings = context.GeneralSettings.FirstOrDefault(x => x.Identifier == ApplicationIdentifier);
        GeneralSettings = generalSettings;
        ServicePath = generalSettings!.ServicePath;
        ErrorMessageFromAddress = generalSettings.ErrorMessageFromAddress;
        ClientValidationEnabled = generalSettings.ClientValidationEnabled.Value;
        UnobtrusiveJavaScriptEnabled = generalSettings.UnobtrusiveJavaScriptEnabled.Value;

        var configuration = Builder();
        //MainDatabaseConnection = generalSettings.MainDatabaseConnection;
        MainDatabaseConnection = configuration.GetConnectionString(nameof(MainDatabaseConnection));
        
    }
}