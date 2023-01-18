using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

namespace KP_RazorPagesEntityFramework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        const string fixedWindowRateLimitedPolicy = "fixed";

        builder.Services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: fixedWindowRateLimitedPolicy, options =>
            {
                options.PermitLimit = 4;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 2;
            }));

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

        app.UseRateLimiter();

        app.Run();
    }
}
