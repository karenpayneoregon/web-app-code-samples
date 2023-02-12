using System.ComponentModel.DataAnnotations;

namespace SeriLogConditional.Models;

public class LogSettings
{
    [Key]
    public int Id { get; set; }
    public bool LogSqlCommand { get; set; }
}
