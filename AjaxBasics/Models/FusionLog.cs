namespace AjaxBasics.Models;

public class FusionLog
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public DateOnly Date { get; set; }
    public override string ToString() => FileName;

}