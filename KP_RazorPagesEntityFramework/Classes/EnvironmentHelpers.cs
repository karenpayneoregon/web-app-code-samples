namespace KP_RazorPagesEntityFramework.Classes;

public class EnvironmentHelpers
{
    public static bool IsDevelopment() => GetEnvironment() == "Development";

    public static bool IsStaging() => GetEnvironment() == "Staging";

    public static bool IsProduction() => GetEnvironment() == "Production";

    private static string GetEnvironment() => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
}


