using System.ComponentModel.DataAnnotations;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.ChangeUserRole;

public class ChangeUserRole : ICommand
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string Role { get; set; }
}
