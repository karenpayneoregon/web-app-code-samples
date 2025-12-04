using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FluentWebApplication.Data;
using FluentWebApplication.Models;

namespace FluentWebApplication.Pages;

public class EditModel(Context context) : PageModel
{
    [BindProperty]
    public Person Person { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || context.Person == null)
        {
            return NotFound();
        }

        var person =  await context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
        if (person == null)
        {
            return NotFound();
        }
        Person = person;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Attach(Person).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(Person.PersonId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./List");
    }

    private bool PersonExists(int id) 
        => (context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
}