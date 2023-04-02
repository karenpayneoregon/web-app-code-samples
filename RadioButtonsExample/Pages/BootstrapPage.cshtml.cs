using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace RadioButtonsExample.Pages
{
    public class BootstrapPageModel : PageModel
    {
        [BindProperty]
        public bool BlueRadio { get; set; }

        [BindProperty]
        public bool RedRadio { get; set; }

        [BindProperty]
        public bool GreenRadio { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Log.Information("Blue {P1}", BlueRadio);
            Log.Information("Red {P1}", RedRadio);
            Log.Information("Green {P1}", GreenRadio);
        }
    }
}
