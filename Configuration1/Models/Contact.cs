
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace Configuration1.Models;

public class Contact
{
    public const string Location = "Contact";


    [Display(Name = "First")]
    [Required]
    public string FirstName { get; set; }

    [Display(Name = "Last")]
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Region { get; set; }
    [Display(Name = "Email")]
    [Required]
    public string EmailAddress { get; set; }

}