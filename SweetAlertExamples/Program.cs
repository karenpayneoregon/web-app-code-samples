using Microsoft.AspNetCore.Mvc;
using Serilog;
using SeriLogThemesLibrary;
using SweetAlertExamples.Classes;
using static System.DateTime;

namespace SweetAlertExamples;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // AutoValidateAntiforgeryTokenAttribute for MessageBox in Index for JavaScript Interop
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.ConfigureFilter(new AutoValidateAntiforgeryTokenAttribute());
        });


        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo.Console(theme: SeriLogCustomThemes.Default());
            configuration.WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"), 
                rollingInterval: RollingInterval.Day, 
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{Exception}]{NewLine}");
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

        //WindowHelper.SetConsoleWindowTitle(app, "Sweet alerts");

        app.Run();
    }
}
