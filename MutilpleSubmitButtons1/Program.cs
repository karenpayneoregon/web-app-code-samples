namespace MultipleSubmitButtons1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
            o.IdleTimeout = TimeSpan.FromMinutes(20);
        });

        builder.Services.Configure<Dictionary<string, string>>(builder.Configuration.GetSection("Programs"));


        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession(); // <-- important

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapFallback(context => {
            context.Response.Redirect("/NotFound");
            return Task.CompletedTask;
        });

        app.Run();
    }
}
