using SecretManagerExample1.Classes;
using Serilog;
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationrootextensions.getdebugview?view=net-9.0-pp
namespace SecretManagerExample1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        SetupLogging.Development();
        var app = builder.Build();
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }else
        {
            // display environment variable while redacting some in NeedsRedactionCheck.
            Log.Information(builder.Configuration.GetDebugView(NeedsRedactionCheck));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }

    private static readonly string[] Keys = 
        [
            "USERDNSDOMAIN", "apiKey", "COMPUTERNAME", "USERNAME", 
            "USERPROFILE", "USERDOMAIN_ROAMINGPROFILE"
        ];

    public static string NeedsRedactionCheck(ConfigurationDebugViewContext context)
    {
        return Keys.Contains(context.Key) ? "[REDACTED]" : context.Value ?? "[NULL]";
    }

    public static string ConfigurationDebugView()
    {
        var configuration = ConfigurationRoot();

        return configuration.GetDebugView();
    }

    private static IConfigurationRoot ConfigurationRoot()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        return configuration;
    }
}
