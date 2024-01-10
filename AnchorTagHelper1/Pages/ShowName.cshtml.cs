using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AnchorTagHelper1.Pages
{
    public class ShowNameModel : PageModel
    {
        [FromQuery(Name = "FullName")]
        public string PersonName { get; set; }

        public string PersonsFullName;

        public void OnGet(string fullName)
        { 

            PersonsFullName = Request.Query["FullName"];

            PersonsFullName = fullName;

            Log.Information("Request query {P1}", Request.Query["FullName"]);
            Log.Information("FromQuery {P1}", PersonName);
            Log.Information("Get param {P1}", fullName);
        }

        public IActionResult OnPostSubmitButton()
        {
            return RedirectToPage("/Index");
        }
    }


}
