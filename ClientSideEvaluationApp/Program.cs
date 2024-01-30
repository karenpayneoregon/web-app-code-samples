using ClientSideEvaluationApp.Classes;
using ClientSideEvaluationApp.Data;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace ClientSideEvaluationApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;

        if (builder.Environment.IsDevelopment())
        {

            builder.Services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source=orders.db")
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log));
        }
        else
        {
            builder.Services.AddDbContext<StoreContext>(options => 
                options.UseSqlite("Data Source=orders.db")
                    .LogTo(new DbContextToFileLogger().Log));
        }

        var app = builder.Build();

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
}
