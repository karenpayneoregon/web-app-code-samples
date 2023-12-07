#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace TheftReportingApp.Models;

public class US_State
{

    public US_State()
    {
        Name = null;
        Abbreviation = null;
    }

    public US_State(string abbreviation, string name)
    {
        Name = name;
        Abbreviation = abbreviation;
    }
    /// <summary>
    /// Name of state
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Two char code for state
    /// </summary>
    public string Abbreviation { get; set; }

    public override string ToString() => $"{Abbreviation} - {Name}";
}