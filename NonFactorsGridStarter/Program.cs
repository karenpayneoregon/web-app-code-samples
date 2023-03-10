using Microsoft.EntityFrameworkCore;
using NonFactorsGridStarter.Classes;
using NonFactorsGridStarter.Data;

namespace NonFactorsGridStarter;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        SetupLogging.Development();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging());

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
