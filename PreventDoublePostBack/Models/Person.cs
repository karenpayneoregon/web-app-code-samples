using Microsoft.AspNetCore.Mvc;

namespace PreventDoublePostBack.Models;

public class Person
{
    [BindProperty]
    public string FirstName { get; set; }

    [BindProperty]
    public string LastName { get; set; }

    public override string ToString() => $"{FirstName} {LastName}";

}