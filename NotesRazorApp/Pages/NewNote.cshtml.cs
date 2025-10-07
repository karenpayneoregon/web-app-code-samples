using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages;

public class NewNoteModel(Context context) : PageModel
{
    public IActionResult OnGet()
    {

        Note = new Note()
        {
            DueDate = DateTime.Now
        };
            
        ViewData[nameof(Category.CategoryName)] = new SelectList(
            context.Category.OrderBy(x => x.CategoryName).ToList(),
            nameof(Note.CategoryId),
            nameof(Note.Category.CategoryName));

        return Page();

    }

    [BindProperty]
    public Note Note { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Note.Attach(Note);

        await context.SaveChangesAsync();

        return RedirectToPage("ViewNotes");
    }
}