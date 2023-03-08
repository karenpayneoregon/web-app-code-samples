using TelerikSamples1.Classes;

namespace TelerikSamples1;

public class Program
{

    /// <summary>
    /// Indicates if a message is to be displayed in Form1 Page
    /// </summary>
    public static bool Shown;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        builder.Services.AddKendo();
        
        WebApplication app = builder.Build();

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
}
