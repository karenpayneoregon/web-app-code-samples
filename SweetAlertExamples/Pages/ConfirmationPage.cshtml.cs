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
            Log.Information("Confirmation: {P1}", Confirmation);
            return Redirect("Index");
        }
    }
}
