using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TempDataSimple.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    [Range(1, int.MaxValue, ErrorMessage = "Identifier must be greater than 0.")]
    public int Identifier { get; set; }

    [TempData]
    public int TempIdentifier { get; set; }

    [TempData]
    public string Message { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        TempIdentifier = Identifier;
        Message = $"Identifier {Identifier} has been set in TempData.";

        return RedirectToPage("Edit");
    }
}
