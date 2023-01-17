using IsolationWebApp.Classes;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace IsolationWebApp.Pages
{
    /// <summary>
    /// There is no code here pertaining to css isolation
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Application spoken language
        /// </summary>
        [FromQuery(Name = "lang")]
        public string Language { get; set; }

        [FromQuery(Name = "id")]
        public string Identifier { get; set; }

        public void OnGet()
        {
            UriBuilder builder = new UriBuilder(HttpContext.Request.GetDisplayUrl());
            Language = builder.GetLanguage();
        }
    }
}