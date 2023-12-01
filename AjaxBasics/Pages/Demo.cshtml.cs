using AjaxBasics.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AjaxBasics.Pages
{
    public class DemoModel : PageModel
    {
        public string Message { get; set; }
        public List<string> MessageList { get; set; }

        public void OnGet()
        {
            Message = "On Demo Page";
        }

        public JsonResult OnGetList() => new(MockData.FusionLogs());
        
        public JsonResult OnGetProducts()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            List<Product> products = new()
            {
                new() { Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                new() { Id = 1002, Name = "Desktop", Description = "HP Desktop" },
                new() { Id = 1003, Name = "Desktop", Description = "Dell Desktop" }
            };

            return new JsonResult(products, options);
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}