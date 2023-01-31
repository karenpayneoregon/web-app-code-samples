using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DropdownEumRazorPages.Pages
{
    public class ReceivingModel : PageModel
    {
        [BindProperty]
        public BookCategories Category { get; set; }
        public void OnGet(BookCategories category)
        {
            Category = category;
        }
    }
}
