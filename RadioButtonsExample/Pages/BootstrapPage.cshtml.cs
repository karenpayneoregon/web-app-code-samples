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
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Log.Information("Blue {P1}", BlueRadio);
            Log.Information("Red {P1}", RedRadio);
        }
    }
}
