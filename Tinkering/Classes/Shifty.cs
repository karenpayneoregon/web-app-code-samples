namespace Tinkering.Classes;
internal class Shifty
{
    public List<Part> Parts =>
    [
        new Part() { Id = 0, Name = "Wheel" },
        new Part() { Id = 0, Name = "Tire" },
        new Part() { Id = 0, Name = "Lug nut" },
        new Part() { Id = 0, Name = "End link" },
        new Part() { Id = 0, Name = "Shock" }
    ];
}

internal class Part
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}

