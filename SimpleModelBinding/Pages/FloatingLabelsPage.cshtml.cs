using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using SimpleModelBinding.Models;

namespace SimpleModelBinding.Pages
{
    /// <summary>
    /// Floating labels
    /// https://getbootstrap.com/docs/5.0/forms/floating-labels/
    /// </summary>
    public class FloatingLabelsPageModel : PageModel
    {

        public FloatingLabelsPageModel()
        {
            Introduction = new Introduction();
        }

        [BindProperty]
        public Introduction Introduction { get; set; }

        /// <summary>
        /// Provides option to turn off auto-complete for a form
        /// </summary>
        [BindProperty]
        public bool UseAutoComplete { get; set; }

        public void OnGet()
        {
            UseAutoComplete = false;
        }
        public IActionResult OnPost()
        {
            Introduction.Name = Request.Form["Name"];
            Introduction.Surname = Request.Form["Surname"];

            /*
             * Can not pass a complex object thus we use a json string
             */
            return RedirectToPage("Index", new { introduction = JsonSerializer.Serialize(Introduction, new JsonSerializerOptions { WriteIndented = true }) });
        }
    }
}
