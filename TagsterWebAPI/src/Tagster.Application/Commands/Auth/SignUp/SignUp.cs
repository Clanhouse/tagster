using System.ComponentModel.DataAnnotations;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.Auth.SignUp;

public class SignUp : ICommand
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(36, ErrorMessage = "Password must be in range between 6-36.", MinimumLength = 6)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
