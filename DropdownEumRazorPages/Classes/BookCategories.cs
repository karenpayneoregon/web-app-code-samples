using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DropdownEumRazorPages.Classes;

public enum BookCategories
{
    [Description("Options")]
    Select = 0,
    [Display( Name = "Space Travel")]
    SpaceTravel = 1,
    [Display( Name = "Adventure")]
    Adventure = 2,
    [Display(Name = "Popular sports")]
    Sports = 3,
    [Display( Name = "Cars")]
    Automobile = 4,
    [Display( Name = "Programming with C#")]
    Programming = 5
}