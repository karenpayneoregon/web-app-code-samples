using Microsoft.AspNetCore.Mvc;

namespace SimpleModelBinding.Models;

[BindProperties]
public class Introduction
{
    public string Name { get; set; }
    public string Surname { get; set; }
}