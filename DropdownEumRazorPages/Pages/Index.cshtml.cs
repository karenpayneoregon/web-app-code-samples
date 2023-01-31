using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DropdownEumRazorPages.Pages;
public class IndexModel : PageModel
{
    public string Message { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

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
        if (Book.Category == BookCategories.Select)
        {
            Message = "Please select a <span class=\"text-danger fw-bold\">category</span>";
            return Page();
        }

        return RedirectToPage("Receiving", new { category = Book.Category });
    }
}
