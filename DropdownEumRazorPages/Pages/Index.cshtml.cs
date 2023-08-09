using System.Configuration;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DropdownEumRazorPages.Pages;
public class IndexModel : PageModel
{
    public string Message { get; set; }

    [BindProperty]
    public Book Book { get; set; }
    public void OnGet()
    {
        Book = new Book()
        {
            Title = "Learning EF Core 7",
            Category = BookCategories.Programming
        };
    }
    public IActionResult OnPost()
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(x => x.Errors.Select(c => c.ErrorMessage))
                .ToArray();

            CommaDelimitedStringCollection result = new();
            result.AddRange(errors);

            //Message = "Please select a <span class=\"text-danger fw-bold\">category</span>";
            Message = $"Errors <span class=\"text-danger fw-bold\">{result.ToString()}</span>";
            return Page();
        }


        //if (Book.Category == BookCategories.Select)
        //{
        //    Message = "Please select a <span class=\"text-danger fw-bold\">category</span>";
        //    return Page();
        //}

        return RedirectToPage("Receiving", new { category = Book.Category });
    }
}
