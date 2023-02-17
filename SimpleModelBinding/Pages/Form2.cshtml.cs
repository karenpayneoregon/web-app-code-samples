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
        IsActive = bogus.IsActive;
    }
    public void OnGet()
    {

    }
    public void OnPost()
    {
        ViewData["sentence"] = $"{Name} {SurName}, {Age} lives in {City} and Active {IsActive.ToYesNo()}.";
        Name = "";
        SurName = "";
        Age = "";
        City = "";
    }
}