using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SimpleModelBinding.Pages;

[BindProperties]
public class Form2Model : PageModel
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Age { get; set; }
    public string City { get; set; }

    public void OnGet() { }
    public void OnPost()
    {
        ViewData["sentence"] = $"{Name} {SurName}, {Age} lives in {City}.";
    }
}