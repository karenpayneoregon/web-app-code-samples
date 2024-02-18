using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MockupApplication.Data;
using MockupApplication.Models;
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS0472
#pragma warning disable CS8618

namespace MockupApplication.Pages
{
    public class EditModel : PageModel
    {
        private readonly Context _context;
        public IDataProtector Protector;

        public EditModel(Context context, IDataProtectionProvider provider)
        {
            _context = context;
            Protector = provider.CreateProtector(nameof(UserLogin));

        }


        [BindProperty]
        public UserLogin UserLogin { get; set; } = default!;

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(string bogus)
        {

            if (TempData["Id"] is not null)
            {
                var test = Convert.ToInt32(Protector.Unprotect(TempData["Id"]?.ToString()!));
            }
            
            var id = Convert.ToInt32(Protector.Unprotect(HttpContext.Session.GetString("Id")));

            //int id = Convert.ToInt32(Protector.Unprotect(bogus));

            if (id == null || _context.UserLogin == null)
            {
                Message = "Missing id";

                return new RedirectToPageResult("/Index");
            }

            //id = 9;
            var userlogin = await _context.UserLogin.FirstOrDefaultAsync(user => user.Id == id);

            if (userlogin == null)
            {
                Message = $"No user with the provided Id {id} exists";

                return new RedirectToPageResult("/Index");

            }

            UserLogin = userlogin;
            return Page();

        }


        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(UserLogin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserLoginExists(int id)
        {
            return (_context.UserLogin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
