using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SerilogCustomLogColors.Classes;

namespace SerilogCustomLogColors.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public IActionResult OnPostButton1(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton1)}");
        return new RedirectToPageResult("Index");
    }


    public IActionResult OnPostButton2(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton2)}");
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton3(IFormCollection data)
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog", 100);
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton4(IFormCollection data)
    {
        Log.Information("Is {day} a weekend day? {IsWeekday} ",DateTime.Today.DayOfWeek,  DateTime.Now.IsWeekDay());
        return new RedirectToPageResult("Index");
    }
}
