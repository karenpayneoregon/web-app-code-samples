using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using TelerikSamples2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TelerikSamples2.Pages;
public class IndexModel : PageModel
{
    public static List<Customer> customers;
    public void OnGet()
    {
        if (customers == null)
        {
            customers = new List<Customer>();

            Enumerable.Range(1, 50).ToList().ForEach(i => customers.Add(new Customer
            {
                CustomerId = i,
                Name = "Customer Name " + i,
                Address = "city " + i
            }));

        }
    }

    public JsonResult OnGetRead()
    {
        var filteredData = customers;
        return new JsonResult(filteredData);
    }
}
