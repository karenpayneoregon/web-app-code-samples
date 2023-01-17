namespace IsolationWebApp.Classes;

public static class Helpers
{
    public static string GetLanguage(this UriBuilder sender)
    {
        if (!sender.Path.Contains("/lang")) return "en";
        var parts = sender.Path.Split('=');
        return string.IsNullOrWhiteSpace(parts[1]) ? "en" : parts[1];

    }
}