using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Models;
using Serilog;

namespace NotesRazorApp.Pages;

public class ViewAllNotesModel : PageModel
{
    private readonly Data.Context _context;

    public ViewAllNotesModel(Data.Context context)
    {
        _context = context;
    }

    [BindProperty]
    public IList<Note> Notes { get;set; } = default!;

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

    public void OnPost()
    {
        var checkedNotes = Notes.Where(note => note.Completed).Select(x => x.NoteId).ToArray();

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