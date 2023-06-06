using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleModelBinding.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public string Message { get; set; }
        public void OnGet(string name)
        {
            Name = name;
            Message = $"<span class=\"text-success fs-4\">Character count for above is <strong>{Name.Length}</strong></span>";
        }
    }
}
