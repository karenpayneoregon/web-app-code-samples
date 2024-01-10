using ConstraintViolationsSamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;

namespace ConstraintViolationsSamples.Pages;
public class IndexModel : PageModel
{
    public List<SelectListItem> Options { get; set; }
    [BindProperty]
    public int SelectedCountry { get; set; }
    private readonly IOptions<List<Countries>> _countries;
    public IndexModel(IOptions<List<Countries>> categories)
    {
        _countries = categories;

    }

    public void OnGet()
    {
        Options = _countries.Value.Select(category => new SelectListItem()
        {
            Value = category.Code,
            Text = category.Name
        }).ToList();
    }

    public RedirectToPageResult OnPost(string code)
    {
        return RedirectToPage("Results", new
        {
            sender = _countries.Value.FirstOrDefault(x => x.Code == code)!.Name
        });
    }

}
