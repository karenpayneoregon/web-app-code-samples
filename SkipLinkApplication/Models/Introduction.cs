using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8618

namespace SkipLinkApplication.Models;

[BindProperties]
public class Introduction
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsActive { get; set; }
}