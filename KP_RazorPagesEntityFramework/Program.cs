using System.Threading.RateLimiting;
using KP_RazorPagesEntityFramework.Classes;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;

namespace KP_RazorPagesEntityFramework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();

        //const string fixedWindowRateLimitedPolicy = "fixed";

        //builder.Services.AddRateLimiter(_ => _
        //    .AddFixedWindowLimiter(policyName: fixedWindowRateLimitedPolicy, options =>
        //    {
        //        options.PermitLimit = 4;
        //        options.Window = TimeSpan.FromSeconds(10);
        //        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //        options.QueueLimit = 2;
        //    }));

        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            SetupLogging.Production();
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

        app.UseRateLimiter();

        app.Run();
    }
}
