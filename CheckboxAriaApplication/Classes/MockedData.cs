namespace CheckboxAriaApplication.Classes;

public class MockedData
{
    public static List<ItemContainer> List() =>
        new()
        {
            new() { Text = "Lettuce", Checked = "false" },
            new() { Text = "Tomato",  Checked = "true" },
            new() { Text = "Mustard", Checked = "false"},
            new() { Text = "Sprouts", Checked = "false"}
        };
}