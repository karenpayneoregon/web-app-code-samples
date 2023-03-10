using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NonFactorsGridStarter.Data;
using NonFactorsGridStarter.Models;
#pragma warning disable CS8618

namespace NonFactorsGridStarter.Pages;
public class IndexModel : PageModel
{
    public Context Context { get; set; }

    public IndexModel(Context context)
    {
        Context = context;
    }
    [BindProperty]
    public List<Customers1> List { get; set; }
    public void OnGet()
    {
        List = Context.Customers1.ToList();

    }


}
