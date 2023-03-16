using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages;

public class NewNoteModel : PageModel
{
    private readonly Context _context;

    public NewNoteModel(Context context)
    {
        _context = context;

        // for setting default due by
        Note = new Note();
    }

    public IActionResult OnGet()
    {
            
        Note.DueDate = DateTime.Now;
            
        ViewData[nameof(Category.CategoryName)] = new SelectList(
            _context.Category.OrderBy(x => x.CategoryName).ToList(),
            nameof(Note.CategoryId),
            nameof(Note.Category.CategoryName));

        return Page();

    }

    [BindProperty]
    public Note Note { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Note.Attach(Note);

        await _context.SaveChangesAsync();

        return RedirectToPage("ViewNotes");
    }
}