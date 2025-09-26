using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SessionStateBasic.Classes;
using SessionExtensions = SessionStateBasic.Classes.SessionExtensions;

namespace SessionStateBasic.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        HttpContext.Session.SetString("Test String", "Karen Payne");
        HttpContext.Session.SetInt32("Test Int", 101);
        HttpContext.Session.SetBoolean("Test Bool", false);
        HttpContext.Session.SetDateOnly("Test Date", new DateOnly(2025, 9, 26));
        
        IsChecked = true;

    }


    public bool IsChecked { get; set; }
    public void OnPostSession()
    {
        ViewData["Test String"] = HttpContext.Session.GetString("Test String");
        ViewData["Test Int"] = HttpContext.Session.GetInt32("Test Int");
        IsChecked = HttpContext.Session.GetBoolean("Test Bool").Value;

        var testDate = HttpContext.Session.GetDateOnly("Test Date");   // DateOnly?
        ViewData["TestDate"] = testDate?.ToString("yyyy-MM-dd");
    }
}
