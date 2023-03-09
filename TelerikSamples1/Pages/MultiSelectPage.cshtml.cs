using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TelerikSamples1.Classes;

#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class MultiSelectPageModel : PageModel
    {

        [BindProperty]
        public string Attendees { get; set; }
        [BindProperty]
        public string Optional { get; set; }

        public List<string> AttendeesList { get; set; }
        public List<string> OptionalList { get; set; }
        public void OnGet()
        {

            AttendeesList = BogusOperations.People(15).Select(x => x.FullName).ToList();
            OptionalList = BogusOperations.People().Select(x => x.FullName).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            Log.Information("Attendees: {P1}", Attendees);
            Log.Information("Optional: {P1}", Optional);

            return RedirectToPage("/Index");
        }
    }
}
