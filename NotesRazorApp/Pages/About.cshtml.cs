using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotesRazorApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public List<string> Phrases = new()
        {
            "Programmer: A machine that turns coffee into code",
            "Software and cathedrals are much the same — first we build them, then we pray.",
            "Programming made the impossible possible. You can have a null object and a constant variable",
            "C# programmers never die. They are just cast into void"
        };
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}