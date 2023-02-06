using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;

namespace SerilogCustomLogColors.Pages
{
    public class OtherPageModel : PageModel
    {
        public void OnGet()
        {
            TempData.Put("container", "Back from Other page");
        }
    }
}
