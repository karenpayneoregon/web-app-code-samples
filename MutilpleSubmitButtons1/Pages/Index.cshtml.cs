using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MultipleSubmitButtons1.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            
        }

        /// <summary>
        /// Gets or sets the number of sessions requested by the user.
        /// </summary>
        /// <remarks>
        /// The value must be at least 1. If the input is invalid, an error message will be displayed.
        /// </remarks>
        /// <value>
        /// An integer representing the number of sessions requested.
        /// </value>
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Enter at least 1.")]
        public int CountInput { get; set; }

        /// <summary>
        /// Gets the count of sessions requested by the user. This property is updated 
        /// during the form submission process based on the user's input and selected action.
        /// </summary>
        /// <value>
        /// The number of sessions requested, or <c>null</c> if the input is invalid or 
        /// an unknown action is submitted.
        /// </value>
        public int? SessionCount { get; private set; }
        public string? Program { get; private set; }

        public void OnGet() { }

        // Single POST handler. No named handlers => no ?handler= in the URL.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var action = Request.Form["action"].ToString();

            SessionCount = CountInput;

            switch (action)
            {
                case "YogaPostures":
                    Program = "Yoga Postures";
                    break;
                case "Meditation":
                    Program = "Kriya and Meditation";
                    break;
                case "RestorativeYoga":
                    Program = "Restorative Yoga";
                    break;
                default:
                    // Unknown/empty action — treat as validation error to surface feedback
                    ModelState.AddModelError(string.Empty, "Unknown action.");
                    SessionCount = null;
                    return Page();
            }

            // No redirect: render the same page; URL stays clean (no ?handler=)
            return Page();
        }
    }
}