using System.ComponentModel.DataAnnotations;
using WorkingWithDateTime.Classes;

namespace WorkingWithDateTime.Models;

public class Person
{
    public int Id { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    [Display(Name = "Birthday")]
    [Required]
    [Range(typeof(DateTime), "1/1/2000", "12/31/2023", ErrorMessage = "{0} must be between {1:d} and {2:d}")]
    public DateTime BirthDate { get; set; }
}
