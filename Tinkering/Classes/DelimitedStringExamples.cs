using System.Globalization;
using System.Configuration;

namespace Tinkering.Classes;
internal class DelimitedStringExamples
{

    public static void DidYouKnow()
    {
        List<int> list = new();

        {
            CommaDelimitedStringCollection result = new();
            result.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]);
            
            Console.WriteLine(result.ToString());

        var monthName = "November";
        if (result.Contains(monthName))
        {
            var position = result.IndexOf(monthName);
            if (position >0)
            {
                Console.WriteLine($"{monthName,15} index is {position}");
            }
        }

            string[] copy = new string[15];
            result.CopyTo(copy,0);

            foreach (var month in copy)
            {
                Console.WriteLine($"{month,14}");
            }
        }

        {
            CommaDelimitedStringCollection result = new();
            result.AddRange(DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[..^1]);
            Console.WriteLine(result.ToString());
        }

        {
            var (day, month, year) = new DateOnly(2022, 7, 1);
            list.Add(year);
        }


        {
            var (day, month, year) = new DateOnly(2023, 7, 1);
            list.Add(year);
        }

        {
            if (list.IndexOf(2018) == -1)
            {
                list.Insert(0,2018);
            }
        }

        

        CommaDelimitedStringCollection delimited = new();
        delimited.AddRange(list.ConvertAll(x => x.ToString()).ToArray());

        Console.WriteLine(delimited.ToString());
    }
}
public static class CommonDeconstruct
{
    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
        (day, month, year) = (date.Day, date.Month, date.Year);
}

