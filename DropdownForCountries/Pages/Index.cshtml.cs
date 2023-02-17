using System.Text.Json;
using DropdownForCountries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

#pragma warning disable CS8618

namespace DropdownForCountries.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public Countries Country { get; set; }

    public void OnGet(string? country)
    {
        if (country is { })
        {
            Country = JsonSerializer.Deserialize<Countries>(country)!;
            Log.Information("Selected country as json {P1}{P2}", Environment.NewLine, country);
        }

    }
}
