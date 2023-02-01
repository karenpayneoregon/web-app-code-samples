namespace RevenueFrontEnd.LanguageExtensions;
public static class BoolExtensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}
