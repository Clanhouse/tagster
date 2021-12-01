using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.Domain.Entities
{
    [Table("Users")]
    public record User(int Id, string Email, string Password, DateTime CreatedAt);
}
