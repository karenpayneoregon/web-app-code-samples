
using System.ComponentModel.DataAnnotations;

namespace Configuration1.Models;

public class Contact
{
    public const string Location = "Contact";


    [Display(Name = "First")]
    public string FirstName { get; set; }

    [Display(Name = "Last")]
    public string LastName { get; set; }

    public string Region { get; set; }
    [Display(Name = "Email")]
    public string EmailAddress { get; set; }

}