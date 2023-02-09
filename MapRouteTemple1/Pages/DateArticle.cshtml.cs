using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemplate1.Pages
{
    public class DateArticleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Month { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Day { get; set; }

        public DateTime DateTime { get; set; }

        /// <summary>
        /// alias is Current  
        /// </summary>
        [BindProperty(SupportsGet = true,Name = "Current")]
        public bool Active { get; set; }

        public void OnGet()
        {
            DateTime = new DateTime(Year, Month, Day);
        }
    }
}
