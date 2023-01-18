using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Revenue.Configuration.Core1.Classes;
public class ConnectionHelpers
{
    public static void StandardLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message));

    }
    public static void NoLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
    }
    public static void NoLoggingNoTrackingSqlServer(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(ConfigurationHelper.ConnectionString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }
}
