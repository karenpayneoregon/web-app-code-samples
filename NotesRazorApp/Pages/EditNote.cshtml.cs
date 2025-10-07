using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages;

public class EditNoteModel(Context context) : PageModel
{
    [BindProperty]
    public Note Note { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || context.Note == null)
        {
            return NotFound();
        }

        var note =  await context.Note.FirstOrDefaultAsync(m => m.NoteId == id);


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
            context.Category.OrderBy(x => x.CategoryName).ToList(),
            nameof(Note.CategoryId),
            nameof(Note.Category.CategoryName));


    }

    public async Task<IActionResult> OnPostAsync(IFormCollection noteData)
    {
       

        /*
         * The following is easier done via Log.Information("Completed {P1}", Note.Completed);
         * but let's look at another way to get at data
         */
        //DateTime dueDate = Convert.ToDateTime(Request.Form["Note.DueDate"]);
        //StringValues completedValues = Request.Form["Note.Completed"];
        //if (completedValues.Count >0)
        //{
        //    Log.Information("Check {P1}", completedValues[0]);
        //}

      

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

        context.Attach(Note).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
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

    private bool NoteExists(int id) => context.Note.Any(e => e.NoteId == id);
}