namespace DropDownWithSelects.Models;

#pragma warning disable CS8618
/// <summary>
/// Model for reading information from appsettings.json
/// </summary>
public class ApplicationFeatures
{
    /// <summary>
    /// Index page section in appsettings.json
    /// </summary>
    public const string Index = "ApplicationFeatures:IndexPage";
    /// <summary>
    /// Index1 page section in appsettings.json
    /// </summary>
    public const string Index1 = "ApplicationFeatures:Index1Page";
    public const string Index2 = "ApplicationFeatures:Index2Page";
    public string SelectText { get; set; }
}