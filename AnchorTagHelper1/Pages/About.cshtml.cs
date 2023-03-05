using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostButton1()
        {
            return RedirectToPage("/Index");

        }
    }
}
