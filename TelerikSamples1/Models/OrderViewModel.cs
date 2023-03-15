using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace TelerikSamples1.Models;

public class OrderViewModel
{
    public int Id { get; set; }
    [Required]
    public decimal? Freight { get;set; }
    [Required]
    public DateTime? OrderDate { get; set; }
    [Required]
    public string ShipCity { get; set; }
    [Required]
    [MinLength(5,ErrorMessage = "Ship Name must be at least 5 characters long")]
    public string ShipName { get; set; }

    public override string ToString() => $"{ShipName,-25}{OrderDate,-25:d}{Freight,-25:C}";

}