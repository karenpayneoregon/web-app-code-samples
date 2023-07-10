using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeLandingPage.Pages;

[AllowAnonymous]
public class IndexModel : PageModel
{
    public IActionResult OnGet() => new RedirectToPageResult("/AlternateIndex");
}