using BogusLibrary1.Classes;
using BogusLibrary1.Interfaces;
using Serilog;
using SeriLogThemesLibrary;

namespace BogusDateOnlyTimeOnlyApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddRazorPages();

        builder.Services.AddSingleton<IMockedData, MockedData>();

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo.Console(theme: SeriLogCustomThemes.Default());
            configuration.WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"),
                rollingInterval: RollingInterval.Day);
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        var app = builder.Build();

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
