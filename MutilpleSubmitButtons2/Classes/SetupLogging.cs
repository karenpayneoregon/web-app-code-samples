﻿using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using static System.DateTime;

namespace MutilpleSubmitButtons2.Classes;

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
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .CreateLogger();
    }

    public static void DevelopmentColored(WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information, theme: AnsiConsoleTheme.Literate));
    }

    public static void DevelopmentAlternate()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
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
