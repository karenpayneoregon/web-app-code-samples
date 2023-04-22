using RadioButtonsExample.Pages;

namespace RadioButtonsExample.Models;

#pragma warning disable CS8618
public class CodingLookup
{
    public int CodingLookupId { get; set; }

    public bool Option1 { get; set; }

    public bool Option2 { get; set; }
    public bool Option3 { get; set; }

    public bool Option4 { get; set; }

    public virtual List<EmployeeInfo> EmployeeInfos { get; } = new();
}