using DropDownWithSelects.Classes;
using DropDownWithSelects.Data;
using DropDownWithSelects.Models;
using Microsoft.EntityFrameworkCore;

namespace DropDownWithSelects;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        SetupLogging.Development();
        ApplicationConfigurations(builder);

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

    /// <summary>
    /// Configuration for reading information from appsettings.json
    /// </summary>
    /// <param name="builder"></param>
    private static void ApplicationConfigurations(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index,
            builder.Configuration.GetSection(ApplicationFeatures.Index));

        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index1,
            builder.Configuration.GetSection(ApplicationFeatures.Index1));

        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index2,
            builder.Configuration.GetSection(ApplicationFeatures.Index2));
    }
}
