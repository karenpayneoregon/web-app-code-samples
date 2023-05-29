using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WorkingWithTempData.Data;

namespace WorkingWithTempData;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        /*
         * Important
         * When configuring the DbContext for development as per below we are exposing
         * sensitive information and should never happen in staging or production thus
         * the environment check.
         */
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(message => Debug.WriteLine(message), LogLevel.Information));
        }
        else
        {
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
