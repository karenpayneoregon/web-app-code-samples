using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages
{
    public class RemoveNoteModel(Context context) : PageModel
    {
        [BindProperty]
        public Note Note { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await context.Note.FirstOrDefaultAsync(m => m.NoteId == id);

            if (note is not null)
            {
                Note = note;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await context.Note.FindAsync(id);
            if (note != null)
            {
                Note = note;
                context.Note.Remove(Note);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./ViewNotes");
        }
    }
}
