using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemplate2.Pages
{
    public class View1Model : PageModel
    {

        [BindProperty(SupportsGet = true)]
        
        public string? SSN { get; set; }
        
        public void OnGet(string? ssn)
        {
            SSN = ssn;
        }
    }
}
