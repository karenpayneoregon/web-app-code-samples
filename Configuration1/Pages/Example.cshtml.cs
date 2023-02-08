using Configuration1.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Configuration1.Pages;

public class ExampleModel : PageModel
{
    public Contact Contact;

    public ExampleModel(IOptions<Contact> options)
    {
        Contact = options.Value;
    }
    public void OnGet()
    {
        var test = Contact.FirstName;
    }
}