using Microsoft.AspNetCore.Mvc;

namespace ChangeLandingPage;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    /// <summary>
    /// https://exceptionnotfound.net/setting-a-custom-default-page-in-asp-net-core-razor-pages/
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {

        //services.AddMvc();

        //services.AddRazorPages()
        //    .AddRazorPagesOptions(options =>
        //    {
        //        options.Conventions.AddPageRoute("/Pages/AlternateIndex", "");
        //    });

        services.AddMvc().AddRazorPagesOptions(options =>
        {
            options.Conventions.AddPageRoute("/Pages/AlternateIndex", "");
        });


        services.AddRazorPages();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
        //defaultFilesOptions.DefaultFileNames.Clear();
        //defaultFilesOptions.DefaultFileNames.Add("/Pages/AlternateIndex.cshtml");
        ////Setting the Default Files
        //app.UseDefaultFiles(defaultFilesOptions);


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}