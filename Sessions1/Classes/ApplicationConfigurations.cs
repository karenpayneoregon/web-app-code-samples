#pragma warning disable CS8618
namespace Sessions1.Classes;

public class ApplicationConfigurations
{
    public const string Key = "ApplicationConfigurations";
    public const string Path = "ApplicationConfigurations:SessionTimeout";
    public int SessionTimeout { get; set; }

}
