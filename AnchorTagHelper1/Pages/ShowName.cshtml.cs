using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class ShowNameModel : PageModel
    {
        public string FullName;
        public void OnGet()
        {
            FullName = Request.Query["FullName"];
        }
        public IActionResult OnPostButton1()
        {

            return RedirectToPage("/Index");

        }
    }
}
