using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RadioButtonsExample.Classes;
using RadioButtonsExample.Data;

namespace RadioButtonsExample;

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

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        SetupLogging.Development();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();


        if (app.Environment.IsDevelopment())
        {
            WindowHelper.ShowConsoleWindow(app);
        }

        app.Run();
    }
}
