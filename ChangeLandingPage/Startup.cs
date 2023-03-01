using ChangeLandingPage.Classes;

namespace ChangeLandingPage;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddTransient<PayneService>();

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


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}