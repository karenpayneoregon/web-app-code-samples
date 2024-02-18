using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MockupApplication.Classes;
using MockupApplication.Data;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using static System.DateTime;

namespace MockupApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddDataProtection()
            // use 7-day lifetime instead of 90-day lifetime
            .SetDefaultKeyLifetime(TimeSpan.FromDays(7));

        builder.Services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });
 
        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        
        /*
         * Important
         * When configuring the DbContext for development as per below we are exposing
         * sensitive information and should never happen in staging or production thus
         * the environment check.
         */
        if (builder.Environment.IsDevelopment())
        {

            SetupLogging.Development();

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log));
        }
        else
        {

            SetupLogging.Production();

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }



        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
