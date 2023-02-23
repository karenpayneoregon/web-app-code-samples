using CheckedListBox.Classes;
using RazorLibrary.Classes;

namespace CheckedListBox;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        SetupLogging.Development();

        builder.Services.AddRazorPages();

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

        if (app.Environment.IsDevelopment())
        {
            WindowHelper.ShowConsoleWindow(app);
        }

        app.Run();
    }
}
