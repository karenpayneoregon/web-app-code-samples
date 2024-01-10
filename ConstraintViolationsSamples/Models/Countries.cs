#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ConstraintViolationsSamples.Models;

public class Countries
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public override string ToString() => Name;

}
        