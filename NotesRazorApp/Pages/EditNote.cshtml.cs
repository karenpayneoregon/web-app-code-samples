using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages;

public class EditNoteModel : PageModel
{
    private readonly Data.Context _context;

    public EditNoteModel(Data.Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Note Note { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Note == null)
        {
            return NotFound();
        }

        var note =  await _context.Note.FirstOrDefaultAsync(m => m.NoteId == id);


        if (note == null)
        {
            return NotFound();
        }

        Note = note;

        /*
         * This is what default scaffolding provides which in the wild is no good so we
         * switch to the category name as per the next line of code below.
         */
        //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");

        SetupCategories();

        return Page();
    }

    private void SetupCategories()
    {
        ViewData["CategoryName"] = new SelectList(
            _context.Category.OrderBy(x => x.CategoryName).ToList(),
            nameof(Note.CategoryId),
            nameof(Note.Category.CategoryName));
    }

    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            SetupCategories();
            return Page();
        }
        
        /*
         * Note.CategoryId is null as we used SelectList on OnGet so we must set
         * the NoteCategoryId to Note.Category.CategoryId
         */
        Note.CategoryId = Note.Category.CategoryId;

        _context.Attach(Note).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NoteExists(Note.NoteId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("ViewNotes");
    }

    private bool NoteExists(int id) => _context.Note.Any(e => e.NoteId == id);
}