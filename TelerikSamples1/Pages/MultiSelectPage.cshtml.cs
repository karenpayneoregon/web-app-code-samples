using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class MultiSelectPageModel : PageModel
    {

        [BindProperty]
        public string Attendees { get; set; }
        [BindProperty]
        public string Optional { get; set; }
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            Log.Information("Attendees: {P1}", Attendees);
            Log.Information("Optional: {P1}", Optional);

            return RedirectToPage("/Index");
        }
    }
}
