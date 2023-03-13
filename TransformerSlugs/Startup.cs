using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TransformerSlugs.Classes;
using static TransformerSlugs.Classes.WindowHelper;

namespace TransformerSlugs;

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
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.Add(
                    new PageRouteTransformerConvention(
                        new SlugingParameterTransformer()));
            });

        //services.Configure<RouteOptions>(options =>
        //{
        //    options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
        //});
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
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();

        if (app.Environment.IsDevelopment())
        {
            ShowConsoleWindow(app);
        }

        app.Run();
    }
}