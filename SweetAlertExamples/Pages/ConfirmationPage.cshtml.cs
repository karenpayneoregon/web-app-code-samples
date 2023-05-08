using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SweetAlertExamples.Classes;
#pragma warning disable CS8618

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

        [BindProperty]
        public int Which { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {

            if (Which == 1)
            {
                /*
                 * Three button dialog result
                 */
                Confirmations confirmation = (Confirmations)ThreeButton;
                Log.Information("ThreeButton {P1} Enum {P2}", ThreeButton, confirmation);
            }
            else
            {
                /*
                 * Two button result
                 */
                if (Confirmation)
                {
                    Log.Information("Two button Delete stuff");
                }
                else
                {
                    Log.Information("Two button Aborted");
                }

            }


        }
    }
}
