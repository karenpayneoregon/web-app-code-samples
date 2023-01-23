﻿using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using static System.DateTime;

namespace KP_RazorPagesEntityFramework.Classes;

/// <summary>
/// For setting up SeriLog to keep Program.Main clean and allows code to be easily copied to other projects.
/// </summary>
public class SetupLogging
{
    /// <summary>
    /// Development logging
    /// </summary>
    public static void Development()
    {
        /*
        * Used to stop SeriLog from logging
        * Serilog doesn't define an Off level, but you can approximate it with
        */
        //LoggingLevelSwitch ls = new() { MinimumLevel = ((LogEventLevel)1 + (int)LogEventLevel.Fatal) };

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            //.MinimumLevel.ControlledBy(ls)
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }

    /// <summary>
    /// Staging logging
    /// </summary>
    public static void Staging()
    {
        // TODO
    }

    /// <summary>
    /// Production logging
    /// </summary>
    public static void Production()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"),
                rollingInterval: RollingInterval.Day)
            .CreateBootstrapLogger();
    }
}
