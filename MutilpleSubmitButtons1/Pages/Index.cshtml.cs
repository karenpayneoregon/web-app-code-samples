using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MultipleSubmitButtons1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

        // This is the form field you type into.
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Enter at least 1.")]
        public int SessionCountInput { get; set; }

        // These properties are rendered by the view (no TempData/Session).
        public int? SessionCount { get; private set; }
        public string? Program { get; private set; }

        public void OnGet() { }

        public IActionResult OnPostYogaPostures()
        {
            if (!ModelState.IsValid)
                return Page(); // validation messages are rendered by the view

            SessionCount = SessionCountInput;
            Program = "Yoga Postures";
            return Page(); // same request, URL will include ?handler=YogaPostures
        }

        public IActionResult OnPostMeditation()
        {
            if (!ModelState.IsValid)
                return Page();

            SessionCount = SessionCountInput;
            Program = "Kriya and Meditation";
            return Page();
        }

        public IActionResult OnPostRestorativeYoga()
        {
            if (!ModelState.IsValid)
                return Page();

            SessionCount = SessionCountInput;
            Program = "Restorative Yoga";
            return Page();
        }
    }
}