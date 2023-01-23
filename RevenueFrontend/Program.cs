using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Revenue.Configuration.Core1;
using RevenueFrontEnd.Classes;
using WebApplication1.Data;

namespace RevenueFrontEnd;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddSingleton<SettingsManager>();

        builder.Services.AddDbContextPool<NorthWind2020Context>(options =>
            options.UseSqlServer(SettingsManager.Configuration.MainDatabaseConnection));


        const string fixedWindowRateLimitedPolicy = "fixed";

        builder.Services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: fixedWindowRateLimitedPolicy, options =>
            {
                options.PermitLimit = 4;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 2;
            }));


        builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
        {
            options.Conventions.Add(new HomePageRouteModelConvention());
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            //app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI();
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