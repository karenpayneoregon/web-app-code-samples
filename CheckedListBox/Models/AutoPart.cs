#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace CheckedListBox.Models;

public class AutoPart
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}
