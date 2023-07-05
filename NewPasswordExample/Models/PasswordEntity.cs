using NewPasswordExample.Rules;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace NewPasswordExample.Models;

public class PasswordEntity
{
    [Required]
    [Display(Name = "Current Password")]
    public string Password { get; set; }

    [Required]
    [NotEqualTo("Password")]
    [Display(Name = "New Password")]
    public string NewPassword { get; set; }

}
