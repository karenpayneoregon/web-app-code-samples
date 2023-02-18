using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleModelBinding.Classes;
using SimpleModelBinding.Models;


namespace SimpleModelBinding.Pages;

[BindProperties]
public class Form2Model : PageModel
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Age { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }

    public Form2Model()
    {
        var bogus = BogusOperations.People().FirstOrDefault();
        Name = bogus!.Name;
        SurName = bogus.SurName;
        Age = bogus.Age;
        City = bogus.City;
        IsActive = true;
    }
    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {

        Person person = new()
        {
            Name = Request.Form["Name"],
            SurName = Request.Form["Surname"],
            City = Request.Form["City"],
            Age = Request.Form["Age"],
            IsActive = IsActive
        };
   

        /*
         * Can not pass a complex object thus we use a json string
         */
        return RedirectToPage("Form2Post", new { person = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true }) });
    }
}


