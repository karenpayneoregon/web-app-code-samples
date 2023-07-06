using IOptionConfiguration.Classes;
using IOptionConfiguration.Models;
using System.Net.Mail;
using Serilog;

namespace IOptionConfiguration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        builder.Services.Configure<ApplicationOptions>(
            builder.Configuration.GetSection(ApplicationOptions.Settings));


        builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
            builder.Configuration.GetSection(TopItemSettings.Month));

        builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
            builder.Configuration.GetSection(TopItemSettings.Year));

        

        var app = builder.Build();

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

        app.Run();
    }
}
