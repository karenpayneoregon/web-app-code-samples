using System.Text.Json;
using System.Text.Json.Serialization;
using MapRouteTemplate2.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemplate2.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IDataProtector Protector;
    [BindProperty]
    public Person Person { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IDataProtectionProvider provider)
    {
        _logger = logger;
        Person = new Person()
        {
            Id = 1,
            FirstName = "Pam", 
            LastName = "Miller",
            SSN = "111-22-3333"
        };

        Protector = provider.CreateProtector("secret");

    }

    public void OnGet()
    {
       
    }

    public IActionResult OnPostAsync()
    {
        return RedirectToPage("View1",  new { p = Protector.Protect(JsonSerializer.Serialize(Person)) });
    }
}
