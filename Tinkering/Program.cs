using Tinkering.Classes;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<string> fileNames = new List<string>()
        {
            "Example12.txt", "Example2.txt", "Example3.txt", "Example4.txt", "Example5.txt", "Example6.txt", 
            "Example7.txt", "Example8.txt", "Example9.txt", "Example10.txt", "Example11.txt", "Example1.txt", 
            "Example13.txt", "Example14.txt", "Example15.txt", "Example16.txt", "Example17.txt", "Example18.txt", 
            "Example19.txt", "Example20.txt"
        };

        fileNames.Sort(new NaturalStringComparer());

        foreach (var item in fileNames)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        List<string> values = new List<string>() {"A11","A9","A1","A22"};

        values.Sort(new NaturalStringComparer());

        foreach (var item in values)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
