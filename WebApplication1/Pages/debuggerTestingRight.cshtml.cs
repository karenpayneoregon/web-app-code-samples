using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class debuggerTestingRightModel : PageModel
    {
        [BindProperty]
        public List<US_State> UsStates { get; set; }
        public List<SelectListItem> Options { get; set; }
        public void OnGet()
        {
            UsStates = StateArray.States(true);
            Options = UsStates.Select(x => new SelectListItem()
            {
                Value = x.Abbreviation,
                Text = x.Name
            }).ToList();
        }
    }
}
