using System.Text.Json;
using MapRouteTemplate2.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8632

namespace MapRouteTemplate2.Pages;

public class View1Model : PageModel
{
    public IDataProtector Protector;

    public View1Model(IDataProtectionProvider provider)
    {
        Protector = provider.CreateProtector("secret");
    }

    [BindProperty]
    public Person? Person { get; set; }
        
    public void OnGet(string p)
    {
        Person = JsonSerializer.Deserialize<Person>(Protector.Unprotect(p));
    }
}