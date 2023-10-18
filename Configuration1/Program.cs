using Configuration1.Classes;
using Configuration1.Models;
using Microsoft.Data.SqlClient;

namespace Configuration1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddOptions<Contact>()
            .BindConfiguration("Contact")
            .ValidateDataAnnotations()
            .Validate(contact => contact.FirstName == "Karen",
                "First name is incorrect")
            .ValidateOnStart();

        builder.Services.AddOptions<ConnectionsConfiguration>()
            .BindConfiguration(nameof(ConnectionsConfiguration))
            .ValidateDataAnnotations()
            .Validate(ConnectionHelpers.CheckConnectionString, "Invalid connection string")
            .ValidateOnStart();


        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<Contact>(
            builder.Configuration.GetSection(Contact.Location));

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
