using Microsoft.AspNetCore.DataProtection;

namespace FriendlyRoutesApp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            // Error un-protecting the session cookie fix
            options.Cookie.Name = ".yourApp.Session";
            options.Cookie.IsEssential = true;
        });

        services.AddMemoryCache();
        services.AddMvc();

        services.AddHttpContextAccessor();

        services.AddRazorPages().AddRazorPagesOptions(options =>
        {
            options.Conventions.AddPageRoute("/Under/Post", "Post/{year}/{month}/{day}/{title}");
            options.Conventions.AddPageRoute("/Under/Dummy", "Silly");
            options.Conventions.AddPageRoute("/Administration/index", "admin");
        });

        services.AddDataProtection()
            .SetDefaultKeyLifetime(TimeSpan.FromDays(7));
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