using ConditionalLayout.Extensions;

namespace ConditionalLayout.Classes;

public class StartupConfiguration
{
    public static string Decide => DateTime.Now.IsWeekDay() ? "_Layout" : "_LayoutWeekend";
}
