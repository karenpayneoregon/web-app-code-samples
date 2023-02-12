using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text.Json;
using Serilog.Configuration;
using SeriLogConditional.Data;
using static System.DateTime;
using SeriLogConditional.Models;

namespace SeriLogConditional.Classes;
public class SetupLogging
{
    public static void CreateDatabase()
    {
        using var context = new Context();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Add(new LogSettings() {LogSqlCommand = true});
        context.SaveChanges();
    }

    public static void DevelopmentDatabase()
    {
        IConfigurationRoot configuration = Configurations.GetLogConfigurationRoot();

        using var context = new Context();

        if (context.LogSettings.FirstOrDefault()!.LogSqlCommand)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
        else
        {
            LoggingLevelSwitch ls = new() { MinimumLevel = ((LogEventLevel)1 + (int)LogEventLevel.Fatal) };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.ControlledBy(ls)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

    }
    /// <summary>
    /// Development logging
    /// </summary>
    public static void DevelopmentJson()
    {
        IConfigurationRoot configuration = Configurations.GetLogConfigurationRoot();


        if (Convert.ToBoolean(configuration.GetSection("Debug")["LogSqlCommand"]))
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
        else
        {
            LoggingLevelSwitch ls = new() { MinimumLevel = ((LogEventLevel)1 + (int)LogEventLevel.Fatal) };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.ControlledBy(ls)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

    }

    public static void Save(bool value)
    {
        try
        {
            LogRoot logRoot = new LogRoot()
            {
                Debug = new Debug() { LogSqlCommand = value }
            };

            string json = JsonSerializer.Serialize(logRoot, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logsettings.json"), json);
        }
        catch (Exception exception)
        {
            Log.Error(exception.Message);
        }
    }

}