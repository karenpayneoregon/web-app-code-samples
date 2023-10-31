using Sessions1.Classes;
using Sessions1.Pages;

namespace Sessions1;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        SetupLogging.Development();


        builder.Services.Configure<ApplicationConfigurations>(
            builder.Configuration
                .GetSection(ApplicationConfigurations.Key));


        builder.Services.AddDistributedMemoryCache();

        /*
         * Setup session timeout read from appsettings.json
         */
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(Utilities.SessionTimeout());
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseSession();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}