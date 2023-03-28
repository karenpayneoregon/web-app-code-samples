using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckboxAriaApplication.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostButton1(IFormCollection data)
        {
            return new RedirectToPageResult("Index");
        }
    }
}
