using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            @ViewData["Title"] = "About";
        }
    }
}
