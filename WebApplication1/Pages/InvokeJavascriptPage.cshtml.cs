using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class InvokeJavascriptPageModel : PageModel
    {
        [BindProperty]
        public bool HasIssues { get; set; } = true;
        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (!HasIssues) return Page();
            ViewData["showError"] = "true";
            ViewData["customError"] = "error message goes here";
            return Page();

        }


    }
}
