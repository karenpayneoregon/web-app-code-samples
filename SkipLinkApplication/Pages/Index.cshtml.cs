using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkipLinkApplication.Models;

namespace SkipLinkApplication.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public Introduction Introduction { get; set; }
    
    [BindProperty]
    public bool UseAutoComplete { get; set; }

    public void OnGet()
    {
        UseAutoComplete = false;
    }
    public IndexModel()
    {
        Introduction = new Introduction();
    }


}
