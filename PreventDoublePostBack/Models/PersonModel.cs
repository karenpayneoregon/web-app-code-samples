using Microsoft.AspNetCore.Mvc;

namespace PreventDoublePostBack.Models;

public class PersonModel
{
    [BindProperty]
    public string FirstName { get; set; }

    [BindProperty]
    public string LastName { get; set; }
}