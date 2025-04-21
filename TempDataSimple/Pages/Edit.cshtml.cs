using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TempDataSimple.Pages
{
    public class EditModel : PageModel
    {
        [TempData]
        public int TempIdentifier { get; set; }

        public int Identifier { get; set; }

        public IActionResult OnGet()
        {
            if (TempIdentifier == 0)
            {
                // No identifier passed, redirect back or show error
                return RedirectToPage("Index");
            }

            Identifier = TempIdentifier;

            // Continue with load logic using Identifier...
            return Page();
        }
    }
}
