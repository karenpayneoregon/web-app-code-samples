using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FriendlyRoutesApp.Pages.Under
{
    public class PostModel : PageModel
    {
        [BindProperty]
        public DateOnly SomeDate { get; set; }
        [BindProperty]
        public string Title { get; set; }
        public void OnGet(int year, int month, int day, string title)
        {
            SomeDate = new DateOnly(year, month, day);
            Title = title;
        }
    }
}
