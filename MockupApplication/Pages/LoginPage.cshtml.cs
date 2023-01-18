using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MockupApplication.Classes;
using MockupApplication.Data;
using MockupApplication.Models;
using Serilog;
using Serilog.Core;

namespace MockupApplication.Pages
{
    public class LoginModel : PageModel
    {
        private readonly Context _context;


        public LoginModel(Context context)
        {
            _context = context;
            CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));
            
            var success = context.CanConnectAsync(cancellationTokenSource.Token);
            if (success == false)
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
            }


        }

        [BindProperty]
        public UserLogin UserLogin { get; set; } = default!;

        [BindProperty]
        public bool InvalidLogin { get; set; }
        public Task<IActionResult> OnGetAsync()
        {
            UserLogin = new UserLogin
            {
                EmailAddress = "payne@comcast.net", Pin = "12345"
            };

            Log.Information("Hello, file logger!");

            return Task.FromResult<IActionResult>(Page());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            

            if (string.IsNullOrWhiteSpace(UserLogin.EmailAddress) || string.IsNullOrWhiteSpace(UserLogin.Pin))
            {
                InvalidLogin = true;
                return Page();
            }

            var result =
                await _context.UserLogin.FirstOrDefaultAsync(x =>
                    x.EmailAddress == UserLogin.EmailAddress && x.Pin == UserLogin.Pin);

            if (result is null)
            {
                InvalidLogin = true;
                return Page();
            }
            
            return RedirectToPage("./UserListing");

        }

        private bool UserLoginExists(int id)
        {
          return (_context.UserLogin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
