using System.Text.Json;
using ClientSideEvaluationApp.Classes;
using ClientSideEvaluationApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ClientSideEvaluationApp.Pages;
public class IndexModel : PageModel
{

    [BindProperty]
    public string JsonData { get; set; }

    private StoreContext _context;
    public IndexModel(StoreContext context)
    {
        _context = context;

        //_context.Database.EnsureDeleted();
        //_context.Database.EnsureCreated();
    }

    public void OnGet()
    {
        var results = _context.Orders.ToList();
        JsonData = JsonSerializer.Serialize(results.Where(x => x.DeliveredDate.IsWeekend()).ToList(), 
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
        Log.Information("\n{P1}",JsonData);
    }
}
