using EF_StringEncryptPropertyValues.Classes.Creations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_StringEncryptPropertyValues.Models;
using Serilog;

namespace EF_StringEncryptPropertyValues.Pages;

public class UsersListModel : PageModel
{
    private readonly Data.Context _context;

    public UsersListModel(Data.Context context)
    {
        _context = context;
    }

    public IList<User> Users { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.User != null)
        {
            Log.Information("Loading data");
            Users = await _context.User.ToListAsync();
        }
    }

    /// <summary>
    /// Code to dynamically create and populate the database
    /// </summary>
    public void CreateDatabase()
    {
        SetupDatabase.CleanDatabase(_context);
        _context.AddRange(BogusOperations.MockedUsers(3));
        _context.SaveChanges();
    }
}