using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MockupApplication.Data;
using Serilog;

namespace MockupApplication;

/*
 * IP address safe list https://learn.microsoft.com/en-us/aspnet/core/security/ip-safelist?view=aspnetcore-7.0
 */

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddDataProtection()
            // use 7-day lifetime instead of 90-day lifetime
            .SetDefaultKeyLifetime(TimeSpan.FromDays(7));

        /*
         * Used to get database connection string
         */
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


        //builder.Host.UseSerilog((context, configuration) =>
        //    configuration.WriteTo.Console());

        /*
         * Important
         * When configuring the DbContext for development as per below we are exposing
         * sensitive information and should never happen in staging or production thus
         * the environment check.
         */
        if (builder.Environment.IsDevelopment())
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"), rollingInterval: RollingInterval.Day)
                .CreateBootstrapLogger();

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(Log.Logger.Information, LogLevel.Information,null));
        }
        else
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"), rollingInterval: RollingInterval.Day)
                .CreateBootstrapLogger();

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(Log.Error, LogLevel.Error));
        }



        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        //app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
