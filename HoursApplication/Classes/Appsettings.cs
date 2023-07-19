#pragma warning disable CS8618
namespace HoursApplication.Classes;

/// <summary>
/// Application options read from appsettings.json
/// </summary>
public class Appsettings
{
    /// <summary>
    /// Title of Index page
    /// </summary>
    public string Title { get; set; }
    public string TimeIncrement { get; set; }
}