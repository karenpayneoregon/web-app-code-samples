namespace IOptionConfiguration.Models;

#pragma warning disable CS8618
public class ApplicationOptions
{
    // section in appsettings.json
    public const string Settings = "AppSettings";
    public string Name { get; set; } = string.Empty;
    public string DefaultConnection { get; set; } = string.Empty;
}