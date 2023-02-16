#pragma warning disable CS8618
namespace RadioButtonsExample.Models;

public class Shape
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public override string ToString() => $"{Name} ({Id})";
    //public override string ToString() => Name;


}
