using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstraintViolationsSamples.Pages
{
    public class ResultsModel : PageModel
    {
        [BindProperty]
        public string CountryName { get; set; }
        public void OnGet(string sender)
        {
            CountryName = sender;
        }
    }
}
