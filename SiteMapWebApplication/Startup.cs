﻿using SiteMapWebApplication.Classes;

namespace SiteMapWebApplication;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        SetupLogging.Development();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();

        app.Run();
    }
}