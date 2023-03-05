using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnchorTagHelper1.Models;

public class Person
{
    public int Id { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    [Display(Name = "Birthday")]
    public DateTime BirthDate { get; set; }
}
