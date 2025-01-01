using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace DropDownWithSelects.Pages
{
    public class otherModel : PageModel
    {
        public void OnGet()
        {
            if (TempData is not null)
            {
                Log.Information("Temp data {P1}", TempData.Count);
            }
            else
            {
                Log.Information("No temp data");
            }
        }
    }
}
