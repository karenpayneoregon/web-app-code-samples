namespace CheckboxAriaApplication.Classes;

public class MockedData
{
    public static List<ItemContainer> List()
    {
        List<ItemContainer> list = new List<ItemContainer>();
        list.Add(new ItemContainer() {Text = "Lettuce", Checked = "false"});
        list.Add(new ItemContainer() {Text = "Tomato", Checked = "true"});
        list.Add(new ItemContainer() {Text = "Mustard", Checked = "false"});
        list.Add(new ItemContainer() {Text = "Sprouts", Checked = "false"});
        return list;
    }
}