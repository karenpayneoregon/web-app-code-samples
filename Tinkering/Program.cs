﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Tinkering.Classes;
using Tinkering.Models;
using Calendar = System.Globalization.Calendar;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        var doneSpanishCharacters = EncoderLibrary.Translator.EncodeSpanishCharacters("Crédito fiscal por ingresos del trabajo:  un beneficio para personas trabajadoras con ingresos bajos a moderados, en particular aquellas con hijos. El crédito fiscal por ingresos del trabajo reduce la cantidad de impuestos adeudados y puede proporcionar un reembolso. Haga clic aquí para obtener más información.");
        Console.WriteLine();
        //InvoiceSample();

        //EnumDemo1();
        //var items = "css/bootstrap-grid.css, css/bootstrap-grid.css.map, css/bootstrap-grid.min.css, css/bootstrap-grid.min.css.map, css/bootstrap-grid.rtl.css, css/bootstrap-grid.rtl.css.map, css/bootstrap-grid.rtl.min.css, css/bootstrap-grid.rtl.min.css.map, css/bootstrap-reboot.css, css/bootstrap-reboot.css.map, css/bootstrap-reboot.min.css, css/bootstrap-reboot.min.css.map, css/bootstrap-reboot.rtl.css, css/bootstrap-reboot.rtl.css.map, css/bootstrap-reboot.rtl.min.css, css/bootstrap-reboot.rtl.min.css.map, css/bootstrap-utilities.css, css/bootstrap-utilities.css.map, css/bootstrap-utilities.min.css, css/bootstrap-utilities.min.css.map, css/bootstrap-utilities.rtl.css, css/bootstrap-utilities.rtl.css.map, css/bootstrap-utilities.rtl.min.css, css/bootstrap-utilities.rtl.min.css.map, css/bootstrap.css, css/bootstrap.css.map, css/bootstrap.min.css, css/bootstrap.min.css.map, css/bootstrap.rtl.css, css/bootstrap.rtl.css.map, css/bootstrap.rtl.min.css, css/bootstrap.rtl.min.css.map, js/bootstrap.bundle.js, js/bootstrap.bundle.js.map, js/bootstrap.bundle.min.js, js/bootstrap.bundle.min.js.map, js/bootstrap.esm.js, js/bootstrap.esm.js.map, js/bootstrap.esm.min.js, js/bootstrap.esm.min.js.map, js/bootstrap.js, js/bootstrap.js.map, js/bootstrap.min.js, js/bootstrap.min.js.map, scss/_accordion.scss, scss/_alert.scss, scss/_badge.scss, scss/_breadcrumb.scss, scss/_button-group.scss, scss/_buttons.scss, scss/_card.scss, scss/_carousel.scss, scss/_close.scss, scss/_containers.scss, scss/_dropdown.scss, scss/_forms.scss, scss/_functions.scss, scss/_grid.scss, scss/_helpers.scss, scss/_images.scss, scss/_list-group.scss, scss/_maps.scss, scss/_mixins.scss, scss/_modal.scss, scss/_nav.scss, scss/_navbar.scss, scss/_offcanvas.scss, scss/_pagination.scss, scss/_placeholders.scss, scss/_popover.scss, scss/_progress.scss, scss/_reboot.scss, scss/_root.scss, scss/_spinners.scss, scss/_tables.scss, scss/_toasts.scss, scss/_tooltip.scss, scss/_transitions.scss, scss/_type.scss, scss/_utilities.scss, scss/_variables-dark.scss, scss/_variables.scss, scss/bootstrap-grid.scss, scss/bootstrap-reboot.scss, scss/bootstrap-utilities.scss, scss/bootstrap.scss, scss/forms/_floating-labels.scss, scss/forms/_form-check.scss, scss/forms/_form-control.scss, scss/forms/_form-range.scss, scss/forms/_form-select.scss, scss/forms/_form-text.scss, scss/forms/_input-group.scss, scss/forms/_labels.scss, scss/forms/_validation.scss, scss/helpers/_clearfix.scss, scss/helpers/_color-bg.scss, scss/helpers/_colored-links.scss, scss/helpers/_focus-ring.scss, scss/helpers/_icon-link.scss, scss/helpers/_position.scss, scss/helpers/_ratio.scss, scss/helpers/_stacks.scss, scss/helpers/_stretched-link.scss, scss/helpers/_text-truncation.scss, scss/helpers/_visually-hidden.scss, scss/helpers/_vr.scss, scss/mixins/_alert.scss, scss/mixins/_backdrop.scss, scss/mixins/_banner.scss, scss/mixins/_border-radius.scss, scss/mixins/_box-shadow.scss, scss/mixins/_breakpoints.scss, scss/mixins/_buttons.scss, scss/mixins/_caret.scss, scss/mixins/_clearfix.scss, scss/mixins/_color-mode.scss, scss/mixins/_color-scheme.scss, scss/mixins/_container.scss, scss/mixins/_deprecate.scss, scss/mixins/_forms.scss, scss/mixins/_gradients.scss, scss/mixins/_grid.scss, scss/mixins/_image.scss, scss/mixins/_list-group.scss, scss/mixins/_lists.scss, scss/mixins/_pagination.scss, scss/mixins/_reset-text.scss, scss/mixins/_resize.scss, scss/mixins/_table-variants.scss, scss/mixins/_text-truncate.scss, scss/mixins/_transition.scss, scss/mixins/_utilities.scss, scss/mixins/_visually-hidden.scss, scss/utilities/_api.scss, scss/vendor/_rfs.scss".Split(',');
        //StringBuilder sb = new StringBuilder();
        //foreach (var item in items)
        //{
        //    sb.AppendLine(item.TrimStart());
        //}
        //File.WriteAllText("nugetData.text", sb.ToString());
        //StandardSortSample();
        //NaturalSortSample();
        //Console.WriteLine(DirectoryHelper.SolutionFolder());
        //DelimitedStringExamples.DidYouKnow();
        //Examples.ReorderDemo();
        //YearsOld1();
        //List<int> list1 = Enumerable
        //    .Range(1, 20)
        //    .Where(x => x % 2 == 0)
        //    .ToList();
        //List<int> list2 = Enumerable
        //    .Range(1, 20)
        //    .ToList();
        //list2.RemoveAll(i => i % 2 == 1);
        //SwitchWhenCanBeRefactored();
        //Console.WriteLine(SwitchRefactored());
        //DelimitedStringExamples.DidYouKnow();


        //EnumDemo1();
        //var items = "css/bootstrap-grid.css, css/bootstrap-grid.css.map, css/bootstrap-grid.min.css, css/bootstrap-grid.min.css.map, css/bootstrap-grid.rtl.css, css/bootstrap-grid.rtl.css.map, css/bootstrap-grid.rtl.min.css, css/bootstrap-grid.rtl.min.css.map, css/bootstrap-reboot.css, css/bootstrap-reboot.css.map, css/bootstrap-reboot.min.css, css/bootstrap-reboot.min.css.map, css/bootstrap-reboot.rtl.css, css/bootstrap-reboot.rtl.css.map, css/bootstrap-reboot.rtl.min.css, css/bootstrap-reboot.rtl.min.css.map, css/bootstrap-utilities.css, css/bootstrap-utilities.css.map, css/bootstrap-utilities.min.css, css/bootstrap-utilities.min.css.map, css/bootstrap-utilities.rtl.css, css/bootstrap-utilities.rtl.css.map, css/bootstrap-utilities.rtl.min.css, css/bootstrap-utilities.rtl.min.css.map, css/bootstrap.css, css/bootstrap.css.map, css/bootstrap.min.css, css/bootstrap.min.css.map, css/bootstrap.rtl.css, css/bootstrap.rtl.css.map, css/bootstrap.rtl.min.css, css/bootstrap.rtl.min.css.map, js/bootstrap.bundle.js, js/bootstrap.bundle.js.map, js/bootstrap.bundle.min.js, js/bootstrap.bundle.min.js.map, js/bootstrap.esm.js, js/bootstrap.esm.js.map, js/bootstrap.esm.min.js, js/bootstrap.esm.min.js.map, js/bootstrap.js, js/bootstrap.js.map, js/bootstrap.min.js, js/bootstrap.min.js.map, scss/_accordion.scss, scss/_alert.scss, scss/_badge.scss, scss/_breadcrumb.scss, scss/_button-group.scss, scss/_buttons.scss, scss/_card.scss, scss/_carousel.scss, scss/_close.scss, scss/_containers.scss, scss/_dropdown.scss, scss/_forms.scss, scss/_functions.scss, scss/_grid.scss, scss/_helpers.scss, scss/_images.scss, scss/_list-group.scss, scss/_maps.scss, scss/_mixins.scss, scss/_modal.scss, scss/_nav.scss, scss/_navbar.scss, scss/_offcanvas.scss, scss/_pagination.scss, scss/_placeholders.scss, scss/_popover.scss, scss/_progress.scss, scss/_reboot.scss, scss/_root.scss, scss/_spinners.scss, scss/_tables.scss, scss/_toasts.scss, scss/_tooltip.scss, scss/_transitions.scss, scss/_type.scss, scss/_utilities.scss, scss/_variables-dark.scss, scss/_variables.scss, scss/bootstrap-grid.scss, scss/bootstrap-reboot.scss, scss/bootstrap-utilities.scss, scss/bootstrap.scss, scss/forms/_floating-labels.scss, scss/forms/_form-check.scss, scss/forms/_form-control.scss, scss/forms/_form-range.scss, scss/forms/_form-select.scss, scss/forms/_form-text.scss, scss/forms/_input-group.scss, scss/forms/_labels.scss, scss/forms/_validation.scss, scss/helpers/_clearfix.scss, scss/helpers/_color-bg.scss, scss/helpers/_colored-links.scss, scss/helpers/_focus-ring.scss, scss/helpers/_icon-link.scss, scss/helpers/_position.scss, scss/helpers/_ratio.scss, scss/helpers/_stacks.scss, scss/helpers/_stretched-link.scss, scss/helpers/_text-truncation.scss, scss/helpers/_visually-hidden.scss, scss/helpers/_vr.scss, scss/mixins/_alert.scss, scss/mixins/_backdrop.scss, scss/mixins/_banner.scss, scss/mixins/_border-radius.scss, scss/mixins/_box-shadow.scss, scss/mixins/_breakpoints.scss, scss/mixins/_buttons.scss, scss/mixins/_caret.scss, scss/mixins/_clearfix.scss, scss/mixins/_color-mode.scss, scss/mixins/_color-scheme.scss, scss/mixins/_container.scss, scss/mixins/_deprecate.scss, scss/mixins/_forms.scss, scss/mixins/_gradients.scss, scss/mixins/_grid.scss, scss/mixins/_image.scss, scss/mixins/_list-group.scss, scss/mixins/_lists.scss, scss/mixins/_pagination.scss, scss/mixins/_reset-text.scss, scss/mixins/_resize.scss, scss/mixins/_table-variants.scss, scss/mixins/_text-truncate.scss, scss/mixins/_transition.scss, scss/mixins/_utilities.scss, scss/mixins/_visually-hidden.scss, scss/utilities/_api.scss, scss/vendor/_rfs.scss".Split(',');
        //StringBuilder sb = new StringBuilder();
        //foreach (var item in items)
        //{
        //    sb.AppendLine(item.TrimStart());
        //}

        //File.WriteAllText("nugetData.text", sb.ToString());


        //StandardSortSample();
        //NaturalSortSample();
        //Console.WriteLine(DirectoryHelper.SolutionFolder());


        //DelimitedStringExamples.DidYouKnow();
        //Examples.ReorderDemo();
        //YearsOld1();



        //List<int> list1 = Enumerable
        //    .Range(1, 20)
        //    .Where(x => x % 2 == 0)
        //    .ToList();

        //List<int> list2 = Enumerable
        //    .Range(1, 20)
        //    .ToList();
        //list2.RemoveAll(i => i % 2 == 1);


        //SwitchWhenCanBeRefactored();
        //Console.WriteLine(SwitchRefactored());



        //DelimitedStringExamples.DidYouKnow();
        string input = "There are 4 numbers in this string: 40.6, 30, and 10 11.555";

        int[] intNumbers = GetNumbers<int>(input).ToArray();
        Console.WriteLine(string.Join(",", intNumbers));
        double[] doubleNumbers = GetNumbers<double>(input).ToArray();
        Console.WriteLine(string.Join(",", doubleNumbers));

        Console.ReadLine();
    }

    private static IEnumerable<T> GetNumbers<T>(string input) where T : struct, IComparable, IFormattable, IConvertible
    {
        List<T> numbers = [];

        ReadOnlySpan<char> span = input.AsSpan();
        int startIndex = 0;

        while (startIndex < span.Length)
        {
            int endIndex = span[startIndex..].IndexOfAny(',', ' ');

            if (endIndex == -1)
            {
                endIndex = span.Length;
            }
            else
            {
                endIndex += startIndex;
            }

            var numberSpan = span.Slice(startIndex, endIndex - startIndex);

            if (numberSpan.Length > 0)
            {
                T number;
                if (typeof(T) == typeof(int))
                {
                    if (int.TryParse(numberSpan, out var intValue))
                    {
                        number = (T)(object)intValue;
                        numbers.Add(number);
                    }
                }
                else if (typeof(T) == typeof(double))
                {
                    if (double.TryParse(numberSpan, out var doubleValue))
                    {
                        number = (T)(object)doubleValue;
                        numbers.Add(number);
                    }
                }
            }

            startIndex = endIndex + 1;
        }

        return numbers;
    }

    private static void GetValuesFromPhone()
    {
        string phoneInput = "The phone number: 333-444-5555";
        string[] numbers = NonDigitPattern().Split(phoneInput).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        foreach (var number in numbers)
        {
            Console.WriteLine($"'{number}'");
        }

        Console.WriteLine();

        string input = "There are 5 numbers in this string: 40, 30, and 10.5  44";
        numbers = NonDigitPattern().Split(input);//.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        foreach (var number in numbers)
        {
            Console.WriteLine($"'{number}'");
        }

        var test = ExtractNumbers(input);



    }

    private static string[] ExtractNumbers(string input)
    {
        return NonDigitPattern().Split(input).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        //return Array.ConvertAll(numbers, double.Parse);
    }

    private static void InvoiceSample()
    {
        List<Customer> list =
        [
            new() { Id = 1, PreFix = "MIC", Name = "Microsoft", InvoiceNumber = "0001" },
            new() { Id = 2, PreFix = "AP", Name = "Apple", InvoiceNumber = "001" }
        ];

        var microsoft = list.FirstOrDefault(x => x.PreFix == "MIC");
        Console.WriteLine(microsoft.CurrentInvoice);
        microsoft.InvoiceNumber = microsoft.CurrentInvoice.NextValue();
        Console.WriteLine(microsoft.CurrentInvoice);
        Console.WriteLine();
    }

    private static void CreateCustomers()
    {
        File.WriteAllText("Customers.json", JsonSerializer.Serialize(CustomersList()));
    }

    private static List<Customer> CustomersList() => 
    [
        new() { Id = 1, PreFix = "MIC", Name = "Microsoft", InvoiceNumber = "0001" },
        new() { Id = 2, PreFix = "AP", Name = "Apple", InvoiceNumber = "001" }
    ];

    private static void YearsOld1()
    {
        int now = 2024_01_15;
        int dob = 1956_09_24;
        var age  = (now - dob) / 10000;
        Console.WriteLine(age);
    }

    private static void YearsOld2()
    {
        DateOnly dateOfBirth = new (1956, 9, 24);
        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));

        int age = (now - dob) / 10000;
        Console.WriteLine(age);
    }

    private static void WeekDemo()
    {
        DateTime dt = new(2023, 7, 21);
        Calendar calendar = new CultureInfo("en-US").Calendar;
        int week = calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        Console.WriteLine(week);
    }

    private static string SwitchWhenCanBeRefactored(string value = "123a") => value switch
        {
            ['1', _, _, _] when char.ToLower(value[4]) == 'a' => "Correct",
            _ => "error"
        };
    

    private static string SwitchRefactored(string value = "123a") => value switch
        {
            ['1', _, _,'A' or 'a'] => "Correct",
            _ => "Incorrect"
        };
    
    

    private static string Validate(string value = "123a") => value switch
        {
            ['1', _, _, 'A' or 'a'] => "Correct",
            _ => "Incorrect"
        };


    public static void ReadFileValidate()
    {

        var lines = File.ReadLines("Data.txt")
            .Select(line => line.Trim().Split(','))
            .ToArray();


        foreach (var line in lines)
        {
            if (line is [_, _, "Beverages" or "beverages" or "DairyProducts" or "GrainsCereals" or "Produce", var amount] && 
                int.TryParse(amount, out var price)) {
                
                var result = Enum.TryParse(line[2], true, out Category category);
                if (result)
                {
                    Console.WriteLine($"Yes, Price {price}");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }


    private static void EnumDemo()
    {
        string[] lines =
        {
            "1,Product1,Beverages, 11",
            "2,Product2,Produce, 19",
            "3,Product3,DairyProducts, 4",
            "4,Product3,DAIRYPRODUCTS, 9",
            "5,Product4,DairyProdccts, 8",
            "6,Product4,, 8",
            "7,Product5,beverages, 6"
        };


        foreach (var currentLine in lines)
        {
            var parts = currentLine.Split(',');
            if (parts is [_, _, 
                    "Beverages" or 
                    "beverages" or 
                    "DairyProducts" or 
                    "GrainsCereals" or 
                    "Produce", 
                    var amount])
            {

                if (Enum.TryParse(parts[2], true, out Category category))
                {
                    Console.WriteLine($"{parts[0],-4}{parts[2], -20} is valid and converted {category}");
                }
            }
            else
            {
                Console.WriteLine($"{parts[0],-4}{parts[2],-20} is not valid");
            }
        }
    }
    private static void EnumDemo1()
    {
        string[] lines =
        {
            "1,Product1,Beverages, 11",
            "2,Product2,Produce, 19",
            "3,Product3,DairyProducts, 4",
            "4,Product3,DAIRYPRODUCTS, 9",
            "5,Product4,DairyProdccts, 8",
            "6,Product5,beverages, 6"
        };

        var linesSplit = lines.Select(line => line.Split(',')).ToArray();

        var categories = Enum.GetNames<Category>();
        foreach (var current in linesSplit)
        {
            
            if (current is not [_, _, var maybeCategory, var amount]) continue;

            if (categories.Contains(maybeCategory, StringComparer.OrdinalIgnoreCase))
            {
                Enum.TryParse(current[2], true, out Category category);
                Console.WriteLine($"{current[0],-5}" +
                                  $"{current[2].PadRight(20,'.')} " +
                                  $"is valid {Convert.ToInt32(amount),10:D2}");
            }
            else
            {
                Console.WriteLine($"{current[0],-5}{current[2].PadRight(20, '.')} is not valid");
            }

        }
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
        List<string> values = ["A11", "A9", "A1", "A22"];

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
        List<string> values = ["A11", "A9", "A1", "A22"];

        
        foreach (var item in values)
        {
            Console.WriteLine(item);
        }
    }

    private static List<string> FileNames() =>
    [
        "Example12.txt", "Example2.txt", "Example3.txt", "Example4.txt",
        "Example5.txt", "Example6.txt", "Example7.txt", "Example8.txt",
        "Example9.txt", "Example10.txt", "Example11.txt", "Example1.txt",
        "Example13.txt", "Example14.txt", "Example15.txt", "Example16.txt",
        "Example17.txt", "Example18.txt", "Example19.txt", "Example20.txt"
    ];

    private static void Print(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
        Console.WriteLine();

        StringBuilder builder = new();
    }

    [GeneratedRegex(@"\D+")]
    private static partial Regex NonDigitPattern();
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
