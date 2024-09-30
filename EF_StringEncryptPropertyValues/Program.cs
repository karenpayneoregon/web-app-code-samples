using EF_StringEncryptPropertyValues.Classes;
using EF_StringEncryptPropertyValues.Data;
using EF_StringEncryptPropertyValues.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

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

        builder.Services.AddOptions<Layout>()
            .BindConfiguration(nameof(Layout))
            .ValidateDataAnnotations()
            .Validate(connections =>
            {
                var dictionary = ConfigurationRoot()
                    .GetSection(Layout.Root)
                    .AsEnumerable()
                    .ToDictionary(x =>
                        x.Key, x =>
                        x.Value);

                return dictionary.ContainsKey(Layout.Features);
            }, "Invalid features")
            .ValidateOnStart();

        // https://stackoverflow.com/questions/77517833/invalid-enum-value-in-a-list-doesnt-get-caught-in-net-configuration-but-get-it
        // set up for failure
        builder.Services.AddOptions<List<MiscSettings>>()
            .BindConfiguration(nameof(MiscSettings))
            .Validate(settings =>
                {
                    // get count of items
                    var itemCount = ConfigurationRoot()
                        .GetSection(nameof(MiscSettings))
                        .GetChildren().Count();

                    var count = Enum.GetNames(typeof(TheEnum)).Length;

                    /*
                     * When reading in items, if TheEnum can not convert its left out
                     */
                    return settings.Count == itemCount;
                }, $"Invalid count of {nameof(MiscSettings)}")
            .ValidateOnStart();


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

    //public static IConfigurationRoot ConfigurationRoot() =>
    //    new ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory())
    //        .AddJsonFile("appsettings.json", optional: false)
    //        .AddEnvironmentVariables()
    //        .Build();
}
