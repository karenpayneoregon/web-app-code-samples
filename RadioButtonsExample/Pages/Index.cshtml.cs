using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.Text.Json;
using RadioButtonsExample.Models;

namespace RadioButtonsExample.Pages;
public class IndexModel : PageModel
{
    public IndexModel()
    {
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }
    public void OnGet(string introduction)
    {
        if (!string.IsNullOrWhiteSpace(introduction))
        {
            Introduction = JsonSerializer.Deserialize<Introduction>(introduction)!;
            // json is only formatted for demonstration only
            Log.Information("Introduction as json {P1}{P2}", Environment.NewLine, introduction);
            Log.Information("Gender {G1}", Introduction.Gender);
        }
    }

    //public IActionResult OnGet() => new RedirectToPageResult("/RadioButton2");
}

