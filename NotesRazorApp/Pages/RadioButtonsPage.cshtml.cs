using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotesRazorApp.Pages
{
    public class RadioButtonsPageModel : PageModel
    {

        public void OnGet()
        {
            Gender = "Unspecified";
        }

        /// <summary>
        /// Other option, an enum
        /// </summary>
        [BindProperty]
        public string? Gender { get; set; }

        public string[] Genders = { "Male", "Female", "Unspecified" };
        public async Task<IActionResult> OnPost()
        {
            await Task.Delay(0);
            var selection = Gender;

            return Page();
        }
    }
}
