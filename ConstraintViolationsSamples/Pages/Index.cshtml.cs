using ConstraintViolationsSamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;

namespace ConstraintViolationsSamples.Pages;
public class IndexModel(IOptions<List<Countries>> categories) : PageModel
{
    public required List<SelectListItem> Options { get; set; }
    [BindProperty]
    public int SelectedCountry { get; set; }

    public void OnGet()
    {
        Options = categories.Value.Select(category => new SelectListItem()
        {
            Value = category.Code,
            Text = category.Name
        }).ToList();
    }

    public RedirectToPageResult OnPost(string code)
    {
        return RedirectToPage("Results", new
        {
            sender = categories.Value.FirstOrDefault(x => x.Code == code)!.Name
        });
    }

}
