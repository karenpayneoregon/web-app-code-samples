using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages;

public class ViewNotesModel : PageModel
{
    private readonly Context _context;

    public ViewNotesModel(Context context)
    {
        _context = context;
    }

    public IList<Note> Note { get;set; } = default!;

    public async Task OnGetAsync()
    {

        if (_context.Note != null)
        {
            Note = await _context.Note.Include(n => n.Category).ToListAsync();
        }
    }
}