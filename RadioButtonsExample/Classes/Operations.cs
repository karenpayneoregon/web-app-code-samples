using RadioButtonsExample.Models;

namespace RadioButtonsExample.Classes;

public class Operations
{
    public static List<Shape?> Shapes => new()
    {
        new () {Id = 1, Name = "Green"},
        new () {Id = 2, Name = "Blue"},
        new () {Id = 3, Name = "Red"},
        new () {Id = 4, Name = "Yellow"},
        new () {Id = 5, Name = "Don't know"}
    };
}
