
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleModelBinding.Models;
using System.Text.Json;

namespace SimpleModelBinding.Pages;

public class Form1Model : PageModel
{
    public Form1Model()
    {
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }
    public void OnGet() { }
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