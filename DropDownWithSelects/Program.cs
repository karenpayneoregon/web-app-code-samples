using DropDownWithSelects.Classes;
using DropDownWithSelects.Data;
using DropDownWithSelects.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DropDownWithSelects;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddSession();
        builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();


        //builder.Services.Configure<CookiePolicyOptions>(options =>
        //{

        //    options.CheckConsentNeeded = context => true;
        //    options.MinimumSameSitePolicy = SameSiteMode.None;
        //});

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(5);
            //options.Cookie.HttpOnly = true;

            options.Cookie.IsEssential = true;
        });

        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //}).AddCookie(options =>
        //{
        //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        //    options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
        //    options.SlidingExpiration = true;
        //});

        //builder.Services.AddMemoryCache();
        //builder.Services.AddHttpContextAccessor();

        builder.Services.AddMvc().AddSessionStateTempDataProvider();
        




        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        SetupLogging.Development();
        ApplicationConfigurations(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }



    /// <summary>
    /// Configuration for reading information from appsettings.json
    /// </summary>
    /// <param name="builder"></param>
    private static void ApplicationConfigurations(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index,
            builder.Configuration.GetSection(ApplicationFeatures.Index));

        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index1,
            builder.Configuration.GetSection(ApplicationFeatures.Index1));

        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index2,
            builder.Configuration.GetSection(ApplicationFeatures.Index2));
    }
}
