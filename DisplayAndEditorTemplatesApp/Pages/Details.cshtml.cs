using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisplayAndEditorTemplatesApp.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace DisplayAndEditorTemplatesApp.Pages
{
    public class DetailsModel(Context context) : PageModel
    {
        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await context.Address.FirstOrDefaultAsync(m => m.Id == id);

            if (address is not null)
            {
                Address = address;

                return Page();
            }

            return NotFound();
        }
    }
}
