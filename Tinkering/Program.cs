using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using Tinkering.Classes;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        StandardSortSample();
        NaturalSortSample();
        
        Console.ReadLine();
    }

    private static void NaturalSortSample()
    {
        Print("Natural sort");
        var fileNames = FileNames();

        fileNames.Sort(new NaturalStringComparer());

        foreach (var item in fileNames)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        List<string> values = new() { "A11", "A9", "A1", "A22" };

        values.Sort(new NaturalStringComparer());

        foreach (var item in values)
        {
            Console.WriteLine(item);
        }
    }

    private static void StandardSortSample()
    {
        Print("Standard sort");
        var fileNames = FileNames();

        foreach (var item in fileNames)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        List<string> values = new List<string>() { "A11", "A9", "A1", "A22" };

        
        foreach (var item in values)
        {
            Console.WriteLine(item);
        }
    }

    private static List<string> FileNames() =>
        new()
        {
            "Example12.txt", "Example2.txt", "Example3.txt", "Example4.txt", 
            "Example5.txt", "Example6.txt", "Example7.txt", "Example8.txt", 
            "Example9.txt", "Example10.txt", "Example11.txt", "Example1.txt",
            "Example13.txt", "Example14.txt", "Example15.txt", "Example16.txt", 
            "Example17.txt", "Example18.txt", "Example19.txt", "Example20.txt"
        };

    private static void Print(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
        Console.WriteLine();

        StringBuilder builder = new();
    }
}

/// <summary>
/// Car car = new("") ;
/// https://gsferreira.com/archive/2022/csharp-11-required-members-the-imperfectly-awesome-feature/
/// </summary>
public class Car
{
    public required string Name { get; set; }
    public required int BrandId { get; set; }

    [SetsRequiredMembers]
    public Car(string name) => Name = name;
}
