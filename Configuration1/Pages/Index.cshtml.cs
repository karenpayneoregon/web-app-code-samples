using Configuration1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace Configuration1.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;

    public Contact Contact { get; set; }
    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        Contact = new Contact();
        _configuration.GetSection(Contact.Location).Bind(Contact);
    }
}

