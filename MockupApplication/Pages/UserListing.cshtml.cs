using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MockupApplication.Data;
using MockupApplication.Models;
#pragma warning disable CS8618

namespace MockupApplication.Pages
{
    public class UserListingModel : PageModel
    {
        private readonly Context _context;
        public IDataProtector Protector;
        public UserListingModel(Context context, IDataProtectionProvider provider)
        {
            _context = context;
            Protector = provider.CreateProtector(GetType().FullName!);
        }

        public IList<UserLogin> UserLogin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserLogin != null)
            {
                UserLogin = await _context.UserLogin.ToListAsync();
                
                List<UserLogin> model = UserLogin.Select(user => new UserLogin()
                {
                    Pin = Protector.Protect(user.Pin), 
                    EmailAddress = Protector.Protect(user.EmailAddress),
                    EncryptedId = Protector.Protect(user.Id.ToString())
                    
                }).ToList();

                UserLogin = model;

            }
        }

    }
}
