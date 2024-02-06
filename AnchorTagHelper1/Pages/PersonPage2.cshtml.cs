using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Serilog;

namespace AnchorTagHelper1.Pages;

public class PersonPage2Model : PageModel
{
    public void OnGet()
    {

        Person = new Person()
        {
            Id = 1, FirstName = "Karen", LastName = "Payne",
            BirthDate = new DateTime(2023,3,3)
        };
    }

    [BindProperty]
    public Person Person { get; set; } = default!;

    [Inject]
    public NavigationManager navigationManager { get; set; }
    public IActionResult OnPost()
    {
        var queryArguments = new Dictionary<string, string>()
        {
            { "id", Person.Id.ToString() },
            { "firstName", Person.FirstName },
            { "lastName", Person.LastName },
            { "birthDate", Person.BirthDate.ToString("yyyy-MM-d") },
        };

        //string url = QueryHelpers.AddQueryString("https://localhost:7268/PersonResultPage2", queryArguments);
        //Log.Information(url);
        //return RedirectToPage(url);
        


        return RedirectToPage("/PersonResultPage2", new
        {
            id = Person.Id,
            firstName = Person.FirstName,
            lastName = Person.LastName,
            birthDate = Person.BirthDate.ToString("yyyy-MM-d")
        });
    }
}
