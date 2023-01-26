using Custom404Page.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Custom404Page.Pages
{
    public class NotFoundModel : PageModel
    {
        public void OnGet()
        {
            @ViewData["Title"] = SiteHelpers.NotFoundPageTitle;
        }
    }
}
