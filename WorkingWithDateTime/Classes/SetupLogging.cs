using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using SeriLogLibrary;

namespace WorkingWithDateTime.Classes;

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
            .WriteTo.Console(theme: SeriLogCustomThemes.Theme1())
            .CreateLogger();
    }


}
