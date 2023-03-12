using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace SweetAlertExamples.Pages
{
    public class ConfirmationPageModel : PageModel
    {
        [BindProperty]
        public bool Confirmation { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            
            if (Confirmation)
            {
                Log.Information("Delete stuff");
                return Redirect("Index");
            }
            else
            {
                Log.Information("Aborted");
                return Page();
            }
            
        }
    }
}
