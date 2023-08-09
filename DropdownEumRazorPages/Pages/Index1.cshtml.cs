using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace DropdownEumRazorPages.Pages
{
    
    public class Index1Model : PageModel
    {
        [BindProperty]
        public string SelectedCar { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Log.Information("Selected car {P1}", SelectedCar);
        }
    }
}
