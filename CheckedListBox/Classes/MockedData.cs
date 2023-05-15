using CheckedListBox.Models;

namespace CheckedListBox.Classes;

public class MockedData
{
    /// <summary>
    /// For a real app data would come from a data source eg. database
    /// </summary>
    public static List<AutoPart> PartsList() =>
        new()
        {
            new () { Id = 1, Name = "Headlights" },
            new () { Id = 2, Name = "Brake Light Switches" },
            new () {Id = 3, Name = "Wiper Switches" },
            new () {Id = 4, Name = "Door Jamb Switches" }
        };
}
