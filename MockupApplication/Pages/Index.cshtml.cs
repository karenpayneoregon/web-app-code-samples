using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MockupApplication.Data;
using MockupApplication.Models;

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

#pragma warning disable CS8618

namespace MockupApplication.Pages;
public class IndexModel : PageModel
{
    public IDataProtector Protector;
    private readonly Context _context;
    public IndexModel(Context context, IDataProtectionProvider provider)
    {
        _context = context;
        Protector = provider.CreateProtector(nameof(UserLogin));
    }

    [TempData]
    public string Message { get; set; }
    [BindProperty]
    [DataType(DataType.Text)]
    [Range(1, 5, ErrorMessage = "Can only be between 1 .. 5")]
    public int? Identifier { get; set; }
    public string EncryptedId { get; set; }

    public void OnGet() { }

    public Task<IActionResult> OnPostAsync()
    {

        if (Identifier is null)
        {
            return Task.FromResult<IActionResult>(Page());
        }

        UserLogin userLogin = _context.UserLogin.FirstOrDefault(x => x.Id == Identifier)!;
        if (userLogin == null)
        {
            return Task.FromResult<IActionResult>(Page());
        }

        EncryptedId = Protector.Protect(Identifier.ToString()!);
        HttpContext.Session.SetString("Id", Protector.Protect(Identifier.ToString()!));

        /*
         * 'bogus` can be anything other than Id, Identifier etc so hackers have
         * no clue what the parameter is for.
         */
        //return Task.FromResult<IActionResult>(RedirectToPage("./Edit", new { bogus = EncryptedId }));

        return Task.FromResult<IActionResult>(RedirectToPage("./Edit"));

    }
}
