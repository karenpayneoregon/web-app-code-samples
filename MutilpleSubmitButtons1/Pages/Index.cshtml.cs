using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MultipleSubmitButtons1.Pages
{
    public class IndexModel : PageModel
    {
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        // Input bound from the form body
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Enter at least 1.")]
        public int SessionCountInput { get; set; }

        // Values rendered by the view after POST
        public int? SessionCount { get; private set; }
        public string? Program { get; private set; }

        public void OnGet() { }

        // Single POST handler. No named handlers => no ?handler= in the URL.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var action = Request.Form["action"].ToString();

            SessionCount = SessionCountInput;

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