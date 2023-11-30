using System.ComponentModel.DataAnnotations;

namespace Configuration1.Models;

#pragma warning disable CS8618
public class ConnectionsConfiguration
{
    [Required]
    public string ActiveEnvironment { get; set; }
    public string Development { get; set; }
    public string Stage { get; set; }
    public string Production { get; set; }
}