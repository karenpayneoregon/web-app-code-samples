using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SweetAlertExamples.Classes;

namespace SweetAlertExamples.Pages
{
    public class ConfirmationPageModel : PageModel
    {
        [BindProperty]
        public bool Confirmation { get; set; }

        [BindProperty]
        public int ThreeButton { get; set; }

        [BindProperty]
        public string Results { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            /*
             * Three button dialog result
             */
            Confirmations confirmation = (Confirmations)ThreeButton;
            Log.Information("ThreeButton {P1} Enum {P2}", ThreeButton, confirmation);
          

            /*
             * Two button result
             */
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
