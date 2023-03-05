using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    [BindProperty]
    public Person Person { get; set; } = new()
    {
        Id = 22,
        FirstName = "Karen",
        LastName = "Payne",
        BirthDate = new(1956, 9, 24)
    };
    public IActionResult OnPostButton1()
    {

        return RedirectToPage("/PersonPage1", new
        {
            id = Person.Id,
            firstName = Person.FirstName,
            lastName = Person.LastName,
            birthDate = Person.BirthDate.ToString("yyyy-MM-d")
        });

    }
}
