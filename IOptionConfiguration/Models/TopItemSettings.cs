namespace IOptionConfiguration.Models;

public class TopItemSettings
{
    public const string Month = "TopItem:Month";
    public const string Year = "TopItem:Year";

    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
}
