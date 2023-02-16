using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioButtonsExample.Models;
using RadioButtonsExample.Classes;
using Serilog;

namespace RadioButtonsExample.Pages;

public class RadioButton1Model : PageModel
{
     
    public List<Shape?> Shapes { get; set; } 
    [BindProperty]
    public int Identifier { get; set; }

    public RadioButton1Model()
    {
        Shapes = Operations.Shapes;
    }
    public void OnGet()
    {
        Shapes = Operations.Shapes;
        Random r = new();
        int identifier = r.Next(1, Shapes.LastOrDefault()!.Id);
        Identifier = identifier;
    }

    public void OnPostSubmit(int identifier)
    {

        var shape = Shapes.FirstOrDefault(x => x!.Id == identifier);
        if (shape is not null)
        {
            Log.Information("Name: {ShapeName} Id: {Id}", shape.Name, identifier);
            if (identifier == 1)
            {
                ViewData["SelectedShape"] = $"{shape.Name} is correct";
            }
            else
            {
                ViewData["SelectedShape"] = $"{shape.Name} is incorrect";
            }
            
        }
        else
        {
            Log.Information("Nothing selected");
        }

    }

}