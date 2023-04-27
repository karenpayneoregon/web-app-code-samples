using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreventDoublePostBack.Pages;

public class Index2Model : PageModel
{
    [BindProperty]
    public Person Person { get; set; }
    public void OnGet()
    {
    }
}

public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}