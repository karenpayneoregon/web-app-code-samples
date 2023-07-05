using Serilog;
using SeriLogThemesLibrary;

namespace IOptionConfiguration.Classes;


public class SetupLogging
{
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }


}
