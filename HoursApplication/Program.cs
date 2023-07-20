using FluentValidation.AspNetCore;
using FluentValidation;
using HoursApplication.Classes;
using HoursApplication.Models;

namespace HoursApplication;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        //builder.Services.AddScoped<IValidator<TimesContainer>, TimesContainerValidator>();
        //builder.Services.AddFluentValidationAutoValidation();

        builder.Services.Configure<Appsettings>(builder.Configuration.GetSection(nameof(Appsettings)));

        SetupLogging.Development();

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

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
