using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace TelerikSamples1.Pages
{
    public class DialogIndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPost(string custom)
        {
            Log.Information("Dialog result {P1}", custom);
        }
    }
}