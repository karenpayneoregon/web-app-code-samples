using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioButtonsExample.Models;
using Serilog;

namespace RadioButtonsExample.Pages;

public class RadioButton2Model : PageModel
{

    /// <summary>
    /// Get a random gender
    /// </summary>
    public void OnGet()
    {
        var values = Enum.GetValues(typeof(GenderTypes));
        Random random = new();
        GenderTypes gender = (GenderTypes)values.GetValue(random.Next(values.Length))!;
        Gender = gender.ToString();
    }

    /// <summary>
    /// Other option, an enum
    /// </summary>
    [BindProperty]
    public string? Gender { get; set; }

    public Person Person { get; set; } = new ();

    public string[] Genders = Enum.GetNames(typeof(GenderTypes));
    public void OnPost()
    {
        ViewData["SelectedShape"] = Gender;

        if (Enum.TryParse(Gender, true,  out GenderTypes gender))
        {
            Person.Gender =gender;
        }

        Log.Information("Selection is {P1}", Gender);
    }
}