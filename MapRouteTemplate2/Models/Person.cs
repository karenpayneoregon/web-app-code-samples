using System.ComponentModel.DataAnnotations;

namespace MapRouteTemplate2.Models;

public class Person
{
    public int Id { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    public string SSN { get; set; }
}
