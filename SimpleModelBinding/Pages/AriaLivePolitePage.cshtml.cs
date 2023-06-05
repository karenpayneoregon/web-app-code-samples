using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SimpleModelBinding.Pages
{
    public class AriaLivePolitePageModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int MaxLength { get; set; }
        public void OnGet()
        {
            MaxLength = 10;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return Page();
            } else if (Name.Length > MaxLength)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("About", new { name = Name });
            }
            
        }
    }
}
