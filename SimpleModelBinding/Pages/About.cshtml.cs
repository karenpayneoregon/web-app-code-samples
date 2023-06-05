using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleModelBinding.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public void OnGet(string name)
        {
            Name = name;
        }
    }
}
