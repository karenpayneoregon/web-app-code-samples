using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace WebApplication1.Pages
{
    public class CascadeDropdownsModel : PageModel
    {
        [BindProperty]
        public string State { get; set; }

        [BindProperty]
        public string County { get; set; }

        [BindProperty]
        public string City { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }
}
