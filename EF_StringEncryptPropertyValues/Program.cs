using EF_StringEncryptPropertyValues.Classes;
using EF_StringEncryptPropertyValues.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_StringEncryptPropertyValues;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging());

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
