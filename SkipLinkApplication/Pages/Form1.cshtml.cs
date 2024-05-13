using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkipLinkApplication.Models;

namespace SkipLinkApplication.Pages;

public class Form1Model : PageModel
{
    public Form1Model()
    {
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }

    /// <summary>
    /// Provides option to turn off auto-complete for a form
    /// </summary>
    [BindProperty]
    public bool UseAutoComplete { get; set; }

    public void OnGet()
    {
        UseAutoComplete = true;
    }
    public IActionResult OnPost()
    {
        Introduction.Name = Request.Form["Name"];
        Introduction.Surname = Request.Form["Surname"];

        /*
         * Can not pass a complex object thus we use a json string
         */
        return RedirectToPage("Index", new { introduction = JsonSerializer.Serialize(Introduction, new JsonSerializerOptions { WriteIndented = true }) });
    }
}