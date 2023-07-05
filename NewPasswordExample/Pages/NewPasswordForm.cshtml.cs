using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewPasswordExample.Models;

namespace NewPasswordExample.Pages
{
    public class NewPasswordFormModel : PageModel
    {
        [BindProperty]
        public PasswordEntity PasswordForm { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
