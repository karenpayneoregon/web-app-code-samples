using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NorthWindExampleApp4.Data;

namespace NorthWindExampleApp4.Classes;

public static class Connections
{
    /// <summary>
    /// Setup EF Core connection by environment.
    /// </summary>
    public static void Setup(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            Development(builder);
        }
        else if (builder.Environment.IsStaging())
        {
            Staging(builder);
        }
        else
        {
            Production(builder);
        }
    }
    private static void Development(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Development"))
                .LogTo(new DbContextLogger().Log, (id, _) => id == RelationalEventId.CommandExecuting));
    }
    private static void Staging(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Staging")));
    }

    private static void Production(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Production")));
    }
}
