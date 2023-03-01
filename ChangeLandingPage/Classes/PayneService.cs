using Microsoft.AspNetCore.Html;

namespace ChangeLandingPage.Classes;

/// <summary>
/// Just a simple service to write formatted strings
/// </summary>
public class PayneService
{
    public HtmlString HelloString => new("<strong>Hello</strong>");
}
