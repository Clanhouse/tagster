using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Users")]
    public record User(int Id, string Email, string Password, DateTime CreatedAt);
}
