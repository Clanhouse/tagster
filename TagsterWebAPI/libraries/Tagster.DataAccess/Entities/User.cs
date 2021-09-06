using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Users")]
<<<<<<< HEAD
    public record User(Guid Id, string Email, string Password, DateTime CreatedAt);
=======
    public record User(int Id, string Email, string Password, DateTime CreatedAt);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
}
