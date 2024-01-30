using SecretManagerExample1.Classes;
using Serilog;

namespace SecretManagerExample1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddRazorPages();
        SetupLogging.Development();
        var app = builder.Build();

        // display environment variable while redacting some in NeedsRedactionCheck.
        Log.Information(builder.Configuration.GetDebugView(NeedsRedactionCheck));

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            
            app.UseExceptionHandler("/Error");
            app.UseHsts();
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
        if (Keys.Contains(context.Key))
        {
            return "[REDACTED]";
        }

        return context.Value ?? "[NULL]";
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
