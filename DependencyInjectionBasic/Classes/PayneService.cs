using static System.DateTime;
using Microsoft.AspNetCore.Html;

namespace DependencyInjectionBasic.Classes;

/// <summary>
/// Just a simple service to write formatted strings
/// </summary>
public class PayneService
{
    public HtmlString HelloString => new($"<span class=\"fw-bold text-secondary\">{Howdy.TimeOfDay()}</span> to you");
}

public class FunnyCatManager : IFunnyCat
{
    public string AreCatsFunny => "Yes";
}

public interface IFunnyCat
{
    string AreCatsFunny { get; }
}

public static class Howdy
{
    public static string TimeOfDay() => Now.Hour switch
    {
        <= 12 => "Good Morning",
        <= 16 => "Good Afternoon",
        <= 20 => "Good Evening",
        _ => "Good Night"
    };


}