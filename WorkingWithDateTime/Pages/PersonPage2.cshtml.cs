using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WorkingWithDateTime.Models;

namespace WorkingWithDateTime.Pages;

public class PersonPage2Model : PageModel
{
    public void OnGet()
    {

        Person = new Person()
        {
            Id = 1, FirstName = "Karen", LastName = "Payne",
            BirthDate = new DateTime(2024,3,3)
        };
    }

    [BindProperty]
    public Person Person { get; set; } = default!;

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            return RedirectToPage("Index");
        }
        else
        {
            return Page();
        }
    }
}
