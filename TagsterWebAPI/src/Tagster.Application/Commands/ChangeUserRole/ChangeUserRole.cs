using System.ComponentModel.DataAnnotations;

namespace Tagster.Application.Commands.ChangeUserRole;

public class ChangeUserRole
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string Role { get; set; }
}
