using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace DropdownEumRazorPages.Pages;

public class Index1Model : PageModel
{
    /// <summary>
    /// value for selected item
    /// </summary>
    [BindProperty]
    public string SelectedCar { get; set; }
    public string Message { get; set; }
    public void OnGet()
    {
    }

    public void OnPost()
    {
        Log.Information("Selected car {P1}", SelectedCar);
    }
}