using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class ShowNameModel : PageModel
    {
        [FromQuery(Name = "FullName")]
        public string PersonName { get; set; }
        //public string FullName;
        public void OnGet()
        {
            //FullName = Request.Query["FullName"];
        }
        public IActionResult OnPostButton1()
        {

            return RedirectToPage("/Index");

        }
    }
}
