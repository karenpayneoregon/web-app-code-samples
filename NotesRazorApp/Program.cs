using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Classes;
using NotesRazorApp.Data;

namespace NotesRazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                SetupLogging.Development();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}