using FluentValidation.AspNetCore;
using FluentValidation;
using HoursApplication.Classes;
using HoursApplication.Models;

namespace HoursApplication;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        
        builder.Services.Configure<Appsettings>(builder.Configuration.GetSection(nameof(Appsettings)));

        SetupLogging.Development();

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
