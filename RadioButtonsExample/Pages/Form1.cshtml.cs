using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioButtonsExample.Models;

namespace RadioButtonsExample.Pages;

public class Form1Model : PageModel
{
    public Form1Model()
    {
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }

    [BindProperty]
    public string? Gender { get; set; }
    public string[] Genders = Enum.GetNames(typeof(GenderTypes));

    public void OnGet()
    {
        @ViewData["header"] = "Header";
        var values = Enum.GetValues(typeof(GenderTypes));

        GenderTypes gender = (GenderTypes)values.GetValue(0)!;
        //Gender = gender.ToString();

        // currently code in front-end is comment out for development mode
        if (Program.Shown) return;
        ViewData["Message"] = "See console window after submitting.";
        Program.Shown = true;

    }
    public IActionResult OnPost()
    {

        Introduction.Name = Request.Form["Name"]!;
        Introduction.Surname = Request.Form["Surname"]!;

        var selectedGender = Request.Form["option"].ToString();

        Introduction.Gender = Enum.TryParse(selectedGender, true, out GenderTypes gender) ? gender : GenderTypes.Unspecified;

        
        /*
         * Can not pass a complex object thus we use a json string
         */
        return RedirectToPage("Index", new { introduction = JsonSerializer.Serialize(Introduction, new JsonSerializerOptions { WriteIndented = true }) });
    }
}