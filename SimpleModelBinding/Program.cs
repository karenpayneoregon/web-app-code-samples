using SimpleModelBinding.Classes;

namespace SimpleModelBinding;

public class Program
{
    public static void Main(string[] args)
    {
        //var builder = WebApplication.CreateBuilder(args);

        //// Add services to the container.
        //builder.Services.AddRazorPages();


        //var app = builder.Build();

        //SetupLogging.Development();

        //// Configure the HTTP request pipeline.
        //if (!app.Environment.IsDevelopment())
        //{
        //    app.UseExceptionHandler("/Error");
        //    app.UseHsts();
        //}

        //app.UseHttpsRedirection();
        //app.UseStaticFiles();

        //app.UseRouting();

        //app.UseAuthorization();

        //app.MapRazorPages();

        //app.Run();

        var builder = WebApplication.CreateBuilder(args);
        SetupLogging.Development();

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        startup.Configure(app, builder.Environment);
    }
}
