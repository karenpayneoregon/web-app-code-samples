using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IsolationWebApp.Pages.Articles
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string? Message { get; private set; }
        public void OnGet()
        {
            Message = "TODO";
        }


        [BindProperty(Name = "lang", SupportsGet = true)]
        public string Language { get; set; }
    }
}
