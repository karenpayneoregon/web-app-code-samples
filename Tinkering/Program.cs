using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using Tinkering.Classes;
using Calendar = System.Globalization.Calendar;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
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
        Examples.ReorderDemo();

        Console.ReadLine();
    }

    private static void WeekDemo()
    {
        DateTime dt = new(2023, 7, 21);
        Calendar calendar = new CultureInfo("en-US").Calendar;
        int week = calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        Console.WriteLine(week);
    }

    private static void SwitchWhenCanBeRefactored(string value = "123")
    {
        var result = value switch
        {
            { Length: 3 } when value[0] == '1' => "passed",
            _ => "error"
        };
        Console.WriteLine(result);
    }

    private static void SwitchRefactored(string value = "123a")
    {
        var result = value switch
        {
            ['1', _, _,'A' or 'a'] => "Correct",
            _ => "Incorrect"
        };
        Console.WriteLine(result);
    }

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
            "4,Product4,DairyProdccts, 8",
            "5,Product5,beverages, 6"
        };


        foreach (var currentLine in lines)
        {
            var parts = currentLine.Split(',');
            if (parts is [_, _, "Beverages" or "beverages" or "DairyProducts" or "GrainsCereals" or "Produce", var amount])
            {
                var result = Enum.TryParse(parts[2], true, out Category category);
                if (result)
                {
                    Console.WriteLine($"{parts[2]} is valid");
                }
            }
            else
            {
                Console.WriteLine($"{parts[2]} is not valid");
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
