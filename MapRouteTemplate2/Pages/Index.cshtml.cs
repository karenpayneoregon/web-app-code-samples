using System.Text.Json;
using System.Text.Json.Serialization;
using MapRouteTemplate2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemplate2.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public Person Person { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Person = new Person()
        {
            Id = 1,
            FirstName = "Pam", 
            LastName = "Miller",
            SSN = "111-22-3333"
        };

    }

    public void OnGet()
    {
       
    }

    public IActionResult OnPostAsync()
    {
        
        return RedirectToPage("View1",  new { person = JsonSerializer.Serialize(Person) });
    }
}
