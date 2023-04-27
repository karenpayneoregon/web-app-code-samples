using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FriendlyRoutesApp.Pages;
public class IndexModel : PageModel
{


    [BindProperty]
    public int Year { get; set; }
    [BindProperty]
    public int Month { get; set; }
    [BindProperty]
    public int Day { get; set; }
    [BindProperty]
    public string Title { get; set; }

    public void OnGet()
    {


    }

    public RedirectToPageResult OnPost()
    {
        return RedirectToPage("Under/Post", new {year = Year, month = Month, day = Day, title = Title});
    }
}
