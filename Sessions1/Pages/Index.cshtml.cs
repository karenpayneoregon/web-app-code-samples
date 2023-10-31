using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;
using Serilog;
using Sessions1.Classes;
using System.Security.Claims;
using System.Security.Principal;


namespace Sessions1.Pages;
public class IndexModel : PageModel
{
    private readonly IOptionsSnapshot<ApplicationConfigurations> _applicationConfigurations;

    [BindProperty]
    public int SessionTimeout { get; set; }

    public IndexModel(IOptionsSnapshot<ApplicationConfigurations> applicationConfigurations)
    {
        _applicationConfigurations = applicationConfigurations;
    }

    public void OnGet()
    {
        HttpContext.Session.SetString("Person", "Payne");
        Log.Information($"Get: {DateTime.Now:HH:mm:ss zz}");
        SessionTimeout = _applicationConfigurations.Value.SessionTimeout;
        
        Log.Information(User.Identity.IsAuthenticated.ToString());
    }

    public void OnPostCreateSession(string sessionName)
    {

        //ViewData["Message"] = HttpContext.Session.GetString(sessionName);
        Log.Information($"Post: {DateTime.Now:HH:mm:ss zz}");

        if (HttpContext.Session.Get(sessionName) is null)
        {
            Log.Information("Timed out");
            ViewData["Message"] = "Timed out";
        }
        else
        {
            ViewData["Message"] = "Active";
        }
    }
}

