using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Models;
using Serilog;

namespace NotesRazorApp.Pages;

/// <summary>
/// This page differs from ViewNotes.cshtml is that on this page the competed property
/// can be changed using for statement and using an input of type checkbox.
/// </summary>
public class ViewAllNotesModel : PageModel
{
    private readonly Data.Context _context;

    public ViewAllNotesModel(Data.Context context)
    {
        _context = context;
    }

    [BindProperty]
    public IList<Note> Notes { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Note != null)
        {
            Notes = await _context
                .Note
                .Include(note => note.Category)
                .ToListAsync();
        }
    }

    public async Task OnPost()
    {
        await SaveChangesForList();
    }

    private async Task SaveChangesForList()
    {
        for (int index = 0; index < Notes.Count; index++)
        {
            var current = Notes[index];
            var note = await _context
                .Note
                .Include(n => n.Category)
                .FirstOrDefaultAsync(x => x.NoteId == Notes[index].NoteId);

            if (note is not null)
            {
                note.Completed = current.Completed;
            }
        }

        await _context.SaveChangesAsync();
    }

    private void DisplayCheckedNotesIdentifiers()
    {
        // get identifiers for checked notes
        int[] checkedNotes = Notes
            .Where(note => note.Completed)
            .Select(x => x.NoteId)
            .ToArray();

        if (checkedNotes.Any())
        {
            // do something with the identifiers
            Log.Information(string.Join(",", checkedNotes));
        }
        else
        {
            Log.Information("Nothing checked");
        }
    }
}