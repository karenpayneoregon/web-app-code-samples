using ClientSideEvaluationApp.Classes;
using ClientSideEvaluationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ClientSideEvaluationApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<StoreContext>(options =>
            options.UseSqlite("Data Source=orders.db")
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(w => 
                    w.Ignore())
                .LogTo(new DbContextToFileLogger().Log));

        SetupLogging.Development();

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
