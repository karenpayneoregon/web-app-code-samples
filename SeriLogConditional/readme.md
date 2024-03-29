﻿# About

Sometimes there is need to log information while other times not. This project demonstrates using conditional logging by allowing the user of an application to toggle logging. The idea is similar to Visual Studio using [devenv](https://learn.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches?view=vs-2022) [/Log](https://learn.microsoft.com/en-us/visualstudio/ide/reference/log-devenv-exe?view=vs-2022).


## Using json file

### Setting file

The file `logsettings.json`

```json
{
  "Debug": {
    "LogSqlCommand": true
  }
}
```

### SeriLog setting 

Are in `SetupLogs.cs`

- `Development` reads from `logsettings.json` to determine if logging should be enabled
- `Save` method updates `logsettings.json` from `LogSettings.cshtml.cs`

```csharp
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text.Json;
using static System.DateTime;
namespace SeriLogConditional.Classes;
public class SetupLogging
{
    /// <summary>
    /// Development logging
    /// </summary>
    public static void Development()
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
```

## Using a database

Keeping it simple we are using SqlLite database.


### Model

```csharp
public class LogSettings
{
    [Key]
    public int Id { get; set; }
    public bool LogSqlCommand { get; set; }
}
```

## Create and populate

```csharp
public static void CreateDatabase()
{
    using var context = new Context();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.Add(new LogSettings() {LogSqlCommand = true});
    context.SaveChanges();
}
```

### Configure logging

```csharp
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
```

### Change setting

```csharp
public class LogSettingsModel : PageModel
{
    IConfigurationRoot _configuration = Configurations.GetLogConfigurationRoot();

    [BindProperty]
    public bool Logging { get; set; }
    public void OnGet()
    {
         using var context = new Context();
        Logging = context.LogSettings.FirstOrDefault()!.LogSqlCommand;
    }

    public void OnPost()
    {
        using var context = new Context();
        context.LogSettings.FirstOrDefault()!.LogSqlCommand = Logging;
        context.SaveChanges();
     }
}
```