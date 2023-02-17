using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8618

namespace RadioButtonsExample.Models;

[BindProperties]
public class Introduction
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public GenderTypes Gender { get; set; }
}