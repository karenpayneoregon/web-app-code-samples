using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#pragma warning disable CS8618

namespace IsolationWebApp.Pages
{
    [AllowAnonymous]
    public class AboutModel : PageModel
    {
        public readonly ILogger<AboutModel> _logger;

        public AboutModel(ILogger<AboutModel> logger)
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
