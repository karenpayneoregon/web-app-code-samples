#pragma warning disable CS8618
namespace CheckedListBox.Models;

public class ServiceModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Checked { get; set; }
    public override string ToString() => $"{Id}  {Name}  {Checked}";

}