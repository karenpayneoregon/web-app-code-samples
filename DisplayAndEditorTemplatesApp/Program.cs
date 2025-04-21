using DisplayAndEditorTemplatesApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DisplayAndEditorTemplatesApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(builder.Environment.IsDevelopment()));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
