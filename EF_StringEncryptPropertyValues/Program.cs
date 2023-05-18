using EF_StringEncryptPropertyValues.Classes;
using EF_StringEncryptPropertyValues.Data;
using EF_StringEncryptPropertyValues.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EF_StringEncryptPropertyValues;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();
        
        builder.Services.AddOptions<Connectionstrings>()
            .BindConfiguration(nameof(Connectionstrings))
            .ValidateDataAnnotations()
            .Validate(connections =>
            {
                if (string.IsNullOrEmpty(connections.DefaultConnection))
                {
                    return false;
                }

                SqlConnectionStringBuilder ssb = new(connections.DefaultConnection);
                return !string.IsNullOrEmpty(ssb.InitialCatalog);

            }, "Invalid connection string")
            .ValidateOnStart();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
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
