using System.ComponentModel.DataAnnotations;

namespace DropdownEumRazorPages.Classes;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    [InvalidEnums(typeof(BookCategories), BookCategories.Select)]
    public BookCategories Category { get; set; }
}
