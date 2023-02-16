using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioButtonsExample.Models;
using System.Reflection;
using RadioButtonsExample.Classes;
using Serilog;

namespace RadioButtonsExample.Pages
{
    public class RadioButton1Model : PageModel
    {
     
        public List<Shape?> Shapes { get; set; } 
        [BindProperty]
        public int Identifier { get; set; }
        [BindProperty]
        public Shape? Shape { get; set; }


        public RadioButton1Model()
        {
            Shapes = Operations.Shapes;
        }
        public void OnGet()
        {
            Shapes = Operations.Shapes;
            Identifier = 5;
        }

        public void OnPostSubmit(int identifier)
        {

            var shape = Shapes.FirstOrDefault(x => x.Id == identifier);
            if (shape is not null)
            {
                Log.Information("Name: {P1}", shape.Name);
                ViewData["SelectedShape"] = shape.Name;
            }
            else
            {
                Log.Information("Nothing selected");
            }

        }

    }
}
