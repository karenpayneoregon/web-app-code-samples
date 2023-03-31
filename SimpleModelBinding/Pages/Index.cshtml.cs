using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleModelBinding.Models;
using System.Text.Json;
using Serilog;

namespace SimpleModelBinding.Pages;
public class IndexModel : PageModel
{

    public IndexModel()
    {
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }

    /// <summary>
    /// From post in form1
    /// </summary>
    /// <param name="introduction"></param>
    public void OnGet(string introduction)
    {
        if (!string.IsNullOrWhiteSpace(introduction))
        {
            Introduction = JsonSerializer.Deserialize<Introduction>(introduction);
            // json is only formatted for demonstration only
            Log.Information("Introduction as json {P1}{P2}", Environment.NewLine, introduction);
        }
    }
}