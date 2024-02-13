#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace WebApplication1.Models;

public class FormType
{
    public int Id { get; set; }
    public string FormName { get; set; }

    public FormType()
    {
        
    }

    public FormType(int id)
    {
        Id = id;
    }
}