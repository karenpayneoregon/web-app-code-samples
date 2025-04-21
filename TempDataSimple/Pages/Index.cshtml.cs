using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TempDataSimple.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int Identifier { get; set; }

    [TempData]
    public int TempIdentifier { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Identifier <= 0)
        {
            ModelState.AddModelError(string.Empty, "Invalid identifier.");
            return Page();
        }

        TempIdentifier = Identifier;
        return RedirectToPage("Edit");
    }
}
