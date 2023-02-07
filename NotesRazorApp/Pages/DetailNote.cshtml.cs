using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using NotesRazorApp.Models;
#pragma warning disable CS8618

namespace NotesRazorApp.Pages;

public class DetailNoteModel : PageModel
{
    private readonly Context _context;

    public DetailNoteModel(Context context)
    {
        _context = context;
    }

    public Note Note { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null || _context.Note is null)
        {
            return NotFound();
        }

        var note = await _context.Note.Include(n => n.Category)
            .FirstOrDefaultAsync(n => n.NoteId == id);

        if (note == null)
        {
            return NotFound();
        }
        // ReSharper disable once RedundantIfElseBlock
        else 
        {
            Note = note;
        }

        return Page();
    }
}